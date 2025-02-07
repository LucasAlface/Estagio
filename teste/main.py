import norair as nor
import serial
import time

# Serial Instance
ser = serial.Serial("COM4", baudrate=115200, bytesize=serial.EIGHTBITS, 
stopbits=serial.STOPBITS_ONE, parity=serial.PARITY_NONE, xonxoff=False)

ser.timeout = 0.5

Errors0 = {
    10: "Message not delivered",
    30: "Peripheral not reachable",
    50: "Malformed or invalid instruction code",
    63: "Unknown Instruction",
    255: "Error message header"
}

Errors1 = {
    10: "Message not delivered",
    30: "Peripheral not reachable",
    50: "Malformed or invalid instruction code",
    63: "Unknown Instruction",
    255: "Error message header"
}

Errors2 = {
    10: "Message not delivered",
    30: "Peripheral not reachable",
    50: "Malformed or invalid instruction code",
    63: "Unknown Instruction",
    255: "Error message header"
}

Errors3 = {
    10: "Message not delivered",
    30: "Peripheral not reachable",
    50: "Malformed or invalid instruction code",
    63: "Unknown Instruction",
    255: "Error message header"
}

def Enviar(data, valueIsNotReturned=None):
    ser.write(bytes(data))
    if valueIsNotReturned == None:
        res = ser.read(32)
        return res

def Error(e):
    if e[0] == 255:
        print(str(e[0]))
    elif e[1] == 63:
        print("Error 63: Unkown instruction")
    elif e[2] == 0:
        print("Not Successful")
    elif e[3] == 0:
        print("Not Successful")
    elif e[3] == 0:
        print("Not Successful")
    elif e[3] == 0:
        print("Not Successful")
    else:
        print("Unknown error " + str(e))
    return e

def Enumerate(obj):
    data=obj.Enumerate(0)
    try:
        Enviar(data)
    except IndexError as e:
         if str(e) == "index out of range":
             print("Timeout error. The OBCS couldn't reach the peripheral that was sent")
    except:
        print("unknown error" + str(e))

def Ping(obj):
    data = obj.Ping()
    if (data[0] == 99 or data[0] == 10):
        return Enviar(data)
    else:
        res = Enviar(data)
        return str.format("ID: %02d Serial Number: %02d%02d%02d%02d%02d" % (res[0],res[1],res[2],res[3],res[4],res[5]))

def SetBacklitColor(obj, r, g, b , w):
    data = obj.SetBacklitColor(r, g, b , w)
    Enviar(data)

def SetLEDBacklitColor(obj, led, r, g, b , w):
    data = obj.SetLEDBacklitColor(led, r, g, b , w)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetOutputType(obj, output, type, flashPeriod, inverted):
    data = obj.SetOutputType(output, type, flashPeriod, inverted)
    return Enviar(data)

def SetOutputOff(obj, output):
    data = obj.SetOutput(output, 0)
    return Enviar(data)

def SetOutputOn(obj, output):
    data = obj.SetOutput(output, 1)
    return Enviar(data)

def ToggleOutput(obj, output):
    data = obj.ToggleOutput(output) 
    return Enviar(data)

def BulkSetOutput(obj, s1, s2, s3, s4):
    data = obj.BulkSetOutput(s1, s2, s3, s4)
    return Enviar(data)

def SetVICe(obj, connector, botJoystick):
    data = obj.SetVICe(connector, botJoystick)
    return Enviar(data)
    
def SetButtonNumber(obj, connector, botJoystick):
    data = obj.SetButtonNumber(connector, botJoystick)
    return Enviar(data)
    
def SetFirstButtonNumber(obj, numButton):
    data = obj.SetFirstButtonNumber(numButton)
    return Enviar(data)[2]
    
def SetDisplayDigit(obj, displayNumber, digitNumber, characterConstructor):
    data = obj.SetDisplayDigit(displayNumber, digitNumber, characterConstructor)
    return Enviar(data)
    
def ReportEnconder(obj, instruction):
    data = obj.ReportEnconder(instruction)
    return Enviar(data)         
    
def ReportInputConnectors(obj):
    data = obj.ReportInputConnectors()
    return Enviar(data)         
    
def SoftReset(obj):
    data = obj.SoftReset()
    Enviar(data)        
    
def HardReset(obj):
    data = obj.SoftReset()
    Enviar(data)         

def ReportEnumeration(obj):
    data = obj.ReportEnumeration()
    res = Enviar(data)
    if res[0] == 0:
        return "No peripherals connected"
    else:
        info = ""
        for i in range(res[0]):
            info += f'ID of peripheral {i+1}: {res[i+1]}\n'
        return info

def ProgramButton(obj, joystickButton, buttonType):
    data = obj.ProgramButton(joystickButton, buttonType)
    res = Enviar(data)
    if res[2] == 1:
        return res

def ReportButtons(obj):
    data = obj.ReportButtons()
    res = Enviar(data)
    if len(res) != 0:
        if res[0] != 255:
            if res[1] != 63:
                buttons = []
                for group in range(2,28):
                    b = res[group]
                    buttons.append(b)
                return buttons
    return ""

def ChangeButtonNumber(obj, connector, joystickButton):
    data = obj.ChangeButtonNumber(connector, joystickButton)
    res = Enviar(data)
    if res[2] == 1:
        return res

def ReportFrequencies(obj):
    data = obj.ReportFrequencies()
    res = Enviar(data)
    if len(res) != 0:
        frequencies = []
        for group in range(2,30):
            b = res[group]
            frequencies.append(b)
        return frequencies
    return ""

def ReportXPDR_SquawkCode(obj):
    data = obj.ReportXPDR_SquawkCode()
    res = Enviar(data)
    Codes = []
    for group in range(2,6):
        b = res[group]
        Codes.append(b)
    return Codes

def SetActiveFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetActiveFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetDecimalIncrement(obj, instrument, digit1, digit2, digit3):
    data = obj.SetDecimalIncrement(instrument, digit1, digit2, digit3)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetDisplayLuminosity(obj, luminosity):
    data = obj.SetDisplayLuminosity(luminosity)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetIntegerIncrement(obj, instrument, digit1, digit2, digit3):
    data = obj.SetIntegerIncrement(instrument, digit1, digit2, digit3)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetMaximumFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetMaximumFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetMinimumFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetMinimumFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetStandByFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetStandByFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetXRDP_DecimalIncrement(obj, digit1, digit2):
    data = obj.SetXRDP_DecimalIncrement(digit1, digit2)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetXRDP_IntegerIncrement(obj, digit1, digit2):
    data = obj.SetXRDP_IntegerIncrement(digit1, digit2)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetXPDR_MaximumSquawk(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_MaximumSquawk(digit1, digit2, digit3, digit4)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetXPDR_MinimumSquawk(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_MinimumSquawk(digit1, digit2, digit3, digit4)
    res = Enviar(data)
    if res[2] == 1:
        return res

def SetXPDR_SquawkCode(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_SquawkCode(digit1, digit2, digit3, digit4)
    res = Enviar(data)
    if res[2] == 1:
        return res
    
def GlobalBacklitColor(r, g, b, w):
    Enviar((bytes([1, 41, r, g, b, w])))
    
def GlobalBacklitColorPerLED(led, r, g, b, w):
    Enviar((bytes([1, 42, led, r, g, b, w])))

def GlobalSoftReset():
    Enviar((bytes([1, 4])))

def GlobalHardReset():
    Enviar((bytes([1, 2])))


if (ser.is_open==False):
    ser.open()

mb2 = nor.MBx24(50, 5000000002)
obcs1 = nor.OBCS()
jport1 = nor.JPort()
rns1 = nor.RNS(31,3100000002)


Enumerate(mb2)
Enumerate(rns1)

# r= ReportFrequencies(jport1)
ProgramButton(jport1, 67, 2)
while True:
    d = ReportFrequencies(rns1)
    if len(d) == 28:
        print (d)
    b = ReportButtons(jport1)
    if len(b) != 0:
        if b[0] & 8 == 8:
            break

ser.close()
