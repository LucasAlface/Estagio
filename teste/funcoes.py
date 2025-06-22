import serial

# Serial Open
ser = serial.Serial("COM4", baudrate=115200, bytesize=serial.EIGHTBITS, 
stopbits=serial.STOPBITS_ONE, parity=serial.PARITY_NONE, xonxoff=False)

# Função para enumerar um periférico
def Enumerate(n1, n2, n3, n4, n5, s):
    if (s == 0):
        s = n1
    ser.write(bytes([99, 7, n1, n2, n3, n4, n5, s]))    
    res = ser.read(32)
    print(res[1])
    
    if (res[1] == 1):
        print("Sucesso")
        print("ID do periférico: " + str(res[0]))
    if (res[1] == 0):
        print("Insucesso")
        print("ID do periférico: " + str(res[0]))


# Função para conectar um VICe
def VICe(ID, connector, botJoystick):
    ser.write(bytes([ID, 75, connector, botJoystick]))
    res = ser.read(32)

    if (res[2] == 0):
        print("A operação não teve sucesso")
    elif (res[2] == 1):
        print("VICe Connection realizada")
    else:
        print("Erro na operação")

# Função para associar um botão do Joystick a um output
def setBotNumber(outConnect, botJoystick):
    ser.write(bytes([50, 80, outConnect, botJoystick]))
    res = ser.read(32)

    if res[2] == 1:
        print("sucesso")
    else:
        print("Erro")





