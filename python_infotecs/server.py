import socket
from prime_factor import mn


def run_server():
    sock = socket.socket()
    sock.bind(('', 9002))
    sock.listen(1)
    conn, addr = sock.accept()

    print('connected:', addr)

    while True:
        data = int(conn.recv(1024).decode('utf-8'))
        if not data:
            break
        abc = str(mn(data)).encode('utf-8')
        conn.send(abc)

    conn.close()


if __name__ == "__main__":
    run_server()
