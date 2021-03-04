import socket
import signal
import sys
import psutil
import time

def signal_handler(sig, frame):
    print('\nDone!')
    sys.exit(0)

signal.signal(signal.SIGINT, signal_handler)
print('Press Ctrl+C to exit...')

ip_addr = "127.0.0.1"
tcp_port = 5005

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

sock.connect((ip_addr, tcp_port))

###########################################################

lastTime = time.time()			# tempo inicial

if len(sys.argv) == 2:
    value = float(sys.argv[1])  # Caso seja passado um valor de periodicidade em segundos
else:
    value = 5                   # Valor de periodicidade Default em segundos

while True:
    try: 
        if time.time() - lastTime >= value:								# verificar periodicidade
            message = ("CPU usage: " + str(psutil.cpu_percent()) + "\nMemory Percentage: " + str(psutil.virtual_memory()[2])).encode() # criar mensagem
            if len(message)>0:
                sock.send(message)										# enviar mensagem com os dados de utilização para o servidor
                response = sock.recv(4096).decode()						# receber echo response do servidor
                print('Server response: \n{}'.format(response))
                print()
            lastTime = time.time()										# atualizar tempo
            
    except (socket.timeout, socket.error):
        print('Server error. Done!')
        sys.exit(0)

