import norair as nor
import serial
import time

port = "COM5"

# Serial Instance
ser = serial.Serial(port, baudrate=115200, bytesize=serial.EIGHTBITS, 
stopbits=serial.STOPBITS_ONE, parity=serial.PARITY_NONE, xonxoff=False)

ser.timeout = 0.1

def Enviar(data, valueIsNotReturned=False):
    ser.write(bytes(data))
    if valueIsNotReturned == False:
        res = ser.read(32)
        return res

def Error(e):
    if e != None:
        if len(e) != 0:
            if e[0] == 255:
                if e[2] == 10:
                    return f'Error: {e[2]} - Not sent'
                elif e[2] == 30:
                    return f'Error: {e[2]} - Not reachable'
                elif e[2] == 50:
                    return f'Error: {e[2]} - Malformed/invalid instruction'
                return f"Unkown Error byte 0 {e}"            
            elif e[1] == 63:
                return f'Error: {e[1]} - ?'          
            return e
    return None

def ErrorSet(e):
    res = Error(e)
    if res==None:
        if e[2]==0:
            return 0
        return e
    return res

def Enumerate(obj, port, s):
    data=obj.Enumerate(port, s)
    return Error(Enviar(data)) 
    
def Ping(obj):
    data = obj.Ping()
    if (data[0] == 99 or data[0] == 10):
        return Error(Enviar(data))
    else:
        res = Error(Enviar(data))
        if res[0] == obj.id:
            return str.format("ID: %02d Serial Number: %02d%02d%02d%02d%02d" % (res[0],res[1],res[2],res[3],res[4],res[5]))
        return res

def SetBacklitColor(obj, r, g, b , w):
    data = obj.SetBacklitColor(r, g, b , w)
    Enviar(data, True)

def SetLEDBacklitColor(obj, led, r, g, b, w):
    data = obj.SetLEDBacklitColor(led, r, g, b, w)
    return ErrorSet(Enviar(data))

def SetOutputType(obj, output, type, flashPeriod, inverted):
    data = obj.SetOutputType(output, type, flashPeriod, inverted)
    return ErrorSet(Enviar(data))

def SetOutput(obj, output, state):
    data = obj.SetOutput(output, state)
    return ErrorSet(Enviar(data))

def ToggleOutput(obj, output):
    data = obj.ToggleOutput(output) 
    return ErrorSet(Enviar(data))

def BulkSetOutput(obj, s1, s2, s3, s4):
    data = obj.BulkSetOutput(s1, s2, s3, s4)
    return ErrorSet(Enviar(data))

def SetVICeType(obj, buttonNumber, buttonType):
    data = obj.SetVICeType(buttonNumber, buttonType)
    return ErrorSet(Enviar(data))

def SetVICe(obj, connector, joystickButton):
    data = obj.SetVICe(connector, joystickButton)
    return ErrorSet(Enviar(data))
    
def SetButtonNumber(obj, connector, joystickButton):
    data = obj.SetButtonNumber(connector, joystickButton)
    return ErrorSet(Enviar(data))
    
def SetFirstButtonNumber(obj, buttonNum):
    data = obj.SetFirstButtonNumber(buttonNum)
    return ErrorSet(Enviar(data))
    
def SetDisplayDigit(obj, displayNumber, digitNumber, characterConstructor):
    data = obj.SetDisplayDigit(displayNumber, digitNumber, characterConstructor)
    return Enviar(data)
    
def ReportEnconder(obj, instruction):
    data = obj.ReportEnconder(instruction)
    return Error(Enviar(data))         
    
def ReportInputConnectors(obj):
    data = obj.ReportInputConnectors()
    return Error(Enviar(data))        
    
def SoftReset(obj):
    data = obj.SoftReset()
    if obj.id == 10:
        return Error(Enviar(data))
    else:
        Enviar(data)        
    
def HardReset(obj):
    data = obj.SoftReset()
    Enviar(data, True)         

def ReportEnumeration(obj):
    data = obj.ReportEnumeration()
    return Error(Enviar(data))
    
def ProgramButton(obj, joystickButton, buttonType):
    data = obj.ProgramButton(joystickButton, buttonType)
    return ErrorSet(Enviar(data))

def ReportButtons(obj):
    data = obj.ReportButtons()
    return Error(Enviar(data))

def ChangeButtonNumber(obj, connector, joystickButton):
    data = obj.ChangeButtonNumber(connector, joystickButton)
    return ErrorSet(Enviar(data))

def ReportFrequencies(obj):
    data = obj.ReportFrequencies()
    return Error(Enviar(data))

def ReportXPDR_SquawkCode(obj):
    data = obj.ReportXPDR_SquawkCode()
    return Error(Enviar(data))

def SetActiveFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetActiveFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Enviar(data))

def SetDecimalIncrement(obj, instrument, digit1, digit2, digit3):
    data = obj.SetDecimalIncrement(instrument, digit1, digit2, digit3)
    return ErrorSet(Enviar(data))

def SetDisplayLuminosity(obj, luminosity):
    data = obj.SetDisplayLuminosity(luminosity)
    return ErrorSet(Enviar(data))

def SetIntegerIncrement(obj, instrument, digit1, digit2, digit3):
    data = obj.SetIntegerIncrement(instrument, digit1, digit2, digit3)
    return ErrorSet(Enviar(data))

def SetMaximumFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetMaximumFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Enviar(data))

def SetMinimumFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetMinimumFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Enviar(data))

def SetStandByFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetStandByFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Enviar(data))

def SetXRDP_DecimalIncrement(obj, digit1, digit2):
    data = obj.SetXRDP_DecimalIncrement(digit1, digit2)
    return ErrorSet(Enviar(data))

def SetXRDP_IntegerIncrement(obj, digit1, digit2):
    data = obj.SetXRDP_IntegerIncrement(digit1, digit2)
    return ErrorSet(Enviar(data))

def SetXPDR_MaximumSquawk(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_MaximumSquawk(digit1, digit2, digit3, digit4)
    return ErrorSet(Enviar(data))

def SetXPDR_MinimumSquawk(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_MinimumSquawk(digit1, digit2, digit3, digit4)
    return ErrorSet(Enviar(data))

def SetXPDR_SquawkCode(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_SquawkCode(digit1, digit2, digit3, digit4)
    return ErrorSet(Enviar(data))
    
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

obcsID = 99
jportID = 10

stateOFF = 0
stateON = 1

mb2 = nor.MBx24(50, 5000000005)
obcs1 = nor.OBCS()
jport1 = nor.JPort()
rns1 = nor.RNS(31,3100000002)
                        

# ********** EXAMPLES **********
# Before testing:
# A time.sleep(0.02) between instructions can prevent errors with memory

# Enumerate before using any peripheral
Enumerate(mb2, obcsID, 0)

print(Ping(mb2)) # Ping the peripheral and print to see the response

print(ReportButtons(jport1))
# SetBacklitColor(mb2, 50, 200, 150, 100) # Changing the backlit color of the MBx24

# for led in range(64): # Leds go from 0-63
#     SetLEDBacklitColor(mb2, led, 200, 50, 100, 150) # Changing the colors of the led's in range
    

time.sleep(0.02)

# print(nor.JoystickUnpack(ReportButtons(jport1)))   




#SetActiveFrequency(rns1, 2, 1, 1, 5, 3, 4, 2)

# while True:
#     d = ReportXPDR_SquawkCode(rns1)
#     print (d)
#     b = ReportButtons(jport1)
#     if b != None:
#         if len(b) != 0:
#             if b[0] & 8 == 8:
#                 break


ser.close()
