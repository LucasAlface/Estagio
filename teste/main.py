"""
Please read this carefully:

DISCLAIMER

THE SOFTWARE AND RELATED DOCUMENTATION IS PROVIDED "AS IS", WITHOUT WARRANTY
OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.

Northern Aircraft Labs, NorAirLabs and GAMAN are brands and trademarks 
of GAMAN Portugal, Lda. and can not be used without expressed written 
consent from GAMAN Portugal, Lda.

All other trademarks and brands are property of their respective owners. 
All company, product and service names mentioned in this software and/or 
documentation are for identification purposes only. Use of these names, 
trademarks and brands does not imply endorsement.

GAMAN Portugal, Lda. is not reliable or responsible for the use of this 
software in any form or shape. Read @ https://norairlabs.com/guarantee-returns

Althougt GAMAN Portugal, Lda.made all efforts to ensure the safety of its 
products, issues and problems may occur out of our control or responsibility.

This software is an open-source MIT licensed for users to enjoy and 
as an example for the use of our SDK. You may distribute, change and even 
sell as far as the Northern Aircraft Labs and GAMAN Portugal is properly 
referenced and MIT license followed. See https://opensource.org/license/MIT

Please, take some time to read this software and try to understand it before 
adapt to your needs or making any changes. It has plenty of comments to ease 
its reading.

Also, read the documentation about SDK and NorAirFramework protocol at 
https://www.norairlabs.com
"""


"""
This file contains the Serial Instance to connect to the OBCS,
functions that send the request structure to the norair.py methods,
functions to read, write and validate the bit array returned by
the norair.py file and examples of how to use the funtions. 
"""

import norair as nor
import serial
import time

port = "COM5"

# Serial Instance
ser = serial.Serial(port, baudrate=115200, bytesize=serial.EIGHTBITS, 
stopbits=serial.STOPBITS_ONE, parity=serial.PARITY_NONE, xonxoff=False)

ser.timeout = 0.1

def Send(data, valueIsNotReturned=False):
    # Function to write and read the byte array returned by the called method in norair.py  
    # "data" - byte array returned by the called method in norair.py
    # "valueIsNotReturned" - Some methods don't return a response, in that case, we set the parameter as "True" and the write is enough to execute it
    ser.write(bytes(data))
    if valueIsNotReturned == False: # Verifies if the method returns something
        res = ser.read(32)
        return res

def Error(data):
    # Verifies if the data returned by the function "Send()" has an error
    # If no error is found, returns the same data
    # All verifications are made according to the SDK error messages
    # The lower the byte, the more serious the error is
    # "data" - Data from the "Sent()" function
    if data != None: # Checks if the data was sent succefully
        if len(data) != 0:
            if data[0] == 255: # Error message header
                # C-Port and J-Port errors
                if data[2] == 10:
                    return f'Error: {data[2]} - Not sent'
                elif data[2] == 30:
                    return f'Error: {data[2]} - Not reachable'
                elif data[2] == 50:
                    return f'Error: {data[2]} - Malformed/invalid instruction'
                return f"Unkown Error byte 0 {data}"    
            # MBx24 and RNS errors        
            elif data[1] == 63:
                return f'Error: {data[1]} - ?'          
            return data # No error found, returns the data
    return None # Data was not successfully sent

def ErrorSet(data):
    # Verifies a specific error that only set methods have
    # The set methods can return a "0" in byte[2] if the set was not successful
    # This function was created, because none-set methods can have a "0" in byte[2] and have no error
    # "data" - Data from the "Sent()" function
    res = Error(data) # Verifies if the data has no other errors
    if res!=None: # Verifies if the "Error()" function didn't return a None
        # Set methods errors
        if data[2] == 0:
            return f'Error: {data[2]} - Set not successful'
        return data # No error found, returns the data
    return res # Returns the same None found in the "Error()" function

# ***** Functions *****

# All functions recieve the object ("obj") as a parameter, that calls its method in the norair.py and represents the "self" argument
# They also recieve the same parameters needed to execute the norair.py methods
# After calling the method, we deal with the returned byte array with the "data" variable, send it to the "Send()" function,
#verify if the "data" has no errors ("Error()", ErrorSet()) and return the values or the error.
# "SetBacklitColor()", "HardReset()" and "SoftReset() (except the J-Port soft reset)" DO NOT return any values
# The code has examples of how you can use and control the returned information

def Enumerate(obj, port, s):
    data = obj.Enumerate(port, s)
    return Error(Send(data)) 
    
def Ping(obj):
    data = obj.Ping()
    return Error(Send(data))

def SetBacklitColor(obj, r, g, b, w):
    data = obj.SetBacklitColor(r, g, b, w)
    Send(data, True)

def SetLEDBacklitColor(obj, led, r, g, b, w):
    data = obj.SetLEDBacklitColor(led, r, g, b, w)
    return ErrorSet(Send(data))

def SetOutputType(obj, output, type, flashPeriod, inverted):
    data = obj.SetOutputType(output, type, flashPeriod, inverted)
    return ErrorSet(Send(data))

def SetOutput(obj, output, state):
    data = obj.SetOutput(output, state)
    return ErrorSet(Send(data))

def ToggleOutput(obj, output):
    data = obj.ToggleOutput(output) 
    return ErrorSet(Send(data))

def BulkSetOutput(obj, s1, s2, s3, s4):
    data = obj.BulkSetOutput(s1, s2, s3, s4)
    return ErrorSet(Send(data))

def SetVICeType(obj, buttonNumber, buttonType):
    data = obj.SetVICeType(buttonNumber, buttonType)
    return ErrorSet(Send(data))

def SetVICe(obj, connector, joystickButton):
    data = obj.SetVICe(connector, joystickButton)
    return ErrorSet(Send(data))
    
def SetButtonNumber(obj, connector, joystickButton):
    data = obj.SetButtonNumber(connector, joystickButton)
    return ErrorSet(Send(data))
    
def SetFirstButtonNumber(obj, buttonNum):
    data = obj.SetFirstButtonNumber(buttonNum)
    return ErrorSet(Send(data))
    
def SetDisplayDigit(obj, displayNumber, digitNumber, characterConstructor):
    data = obj.SetDisplayDigit(displayNumber, digitNumber, characterConstructor)
    return Send(data)
    
def ReportEnconder(obj, instruction):
    data = obj.ReportEnconder(instruction)
    return Error(Send(data))         
    
def ReportInputConnectors(obj):
    data = obj.ReportInputConnectors()
    return Error(Send(data))        
    
def SoftReset(obj):
    data = obj.SoftReset()
    if obj.id == 10: # Verifies if the object is the J-Port
        return Error(Send(data))
    else:
        Send(data, True)        
    
def HardReset(obj):
    data = obj.SoftReset()
    Send(data, True)         

def ReportEnumeration(obj):
    data = obj.ReportEnumeration()
    return Error(Send(data))
    
def ProgramButton(obj, joystickButton, buttonType):
    data = obj.ProgramButton(joystickButton, buttonType)
    return ErrorSet(Send(data))

def ReportButtons(obj):
    data = obj.ReportButtons()
    return Error(Send(data))

def ChangeButtonNumber(obj, connector, joystickButton):
    data = obj.ChangeButtonNumber(connector, joystickButton)
    return ErrorSet(Send(data))

def ReportFrequencies(obj):
    data = obj.ReportFrequencies()
    return Error(Send(data))

def ReportXPDR_SquawkCode(obj):
    data = obj.ReportXPDR_SquawkCode()
    return Error(Send(data))

def SetActiveFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetActiveFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Send(data))

def SetDecimalIncrement(obj, instrument, digit1, digit2, digit3):
    data = obj.SetDecimalIncrement(instrument, digit1, digit2, digit3)
    return ErrorSet(Send(data))

def SetDisplayLuminosity(obj, luminosity):
    data = obj.SetDisplayLuminosity(luminosity)
    return ErrorSet(Send(data))

def SetIntegerIncrement(obj, instrument, digit1, digit2, digit3):
    data = obj.SetIntegerIncrement(instrument, digit1, digit2, digit3)
    return ErrorSet(Send(data))

def SetMaximumFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetMaximumFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Send(data))

def SetMinimumFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetMinimumFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Send(data))

def SetStandByFrequency(obj, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
    data = obj.SetStandByFrequency(instrument, digit1, digit2, digit3, digit4, digit5, digit6)
    return ErrorSet(Send(data))

def SetXRDP_DecimalIncrement(obj, digit1, digit2):
    data = obj.SetXRDP_DecimalIncrement(digit1, digit2)
    return ErrorSet(Send(data))

def SetXRDP_IntegerIncrement(obj, digit1, digit2):
    data = obj.SetXRDP_IntegerIncrement(digit1, digit2)
    return ErrorSet(Send(data))

def SetXPDR_MaximumSquawk(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_MaximumSquawk(digit1, digit2, digit3, digit4)
    return ErrorSet(Send(data))

def SetXPDR_MinimumSquawk(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_MinimumSquawk(digit1, digit2, digit3, digit4)
    return ErrorSet(Send(data))

def SetXPDR_SquawkCode(obj, digit1, digit2, digit3, digit4):
    data = obj.SetXPDR_SquawkCode(digit1, digit2, digit3, digit4)
    return ErrorSet(Send(data))
    
# ***** WALL methods *****

# methods that send an instruction to ALL the connected peripherals 
# Does not affect the OBCS
# The "GlobalSoftReset()" and "GlobalHardReset()" also affect the J-Port

# Commands 
GLOBAL_BACKLIT_COLOR_CMD = 41
GLOBAL_BACKLIT_COLOR_PER_LED_CMD = 42
GLOBAL_SOFT_RESET_CMD = 4
GLOBAL_HARD_RESET_CMD = 2

def GlobalBacklitColor(r, g, b, w):
    Send((bytes([1, GLOBAL_BACKLIT_COLOR_CMD, r, g, b, w])))
    
def GlobalBacklitColorPerLED(led, r, g, b, w):
    Send((bytes([1, GLOBAL_BACKLIT_COLOR_PER_LED_CMD, led, r, g, b, w])))

def GlobalSoftReset():
    Send((bytes([1, GLOBAL_SOFT_RESET_CMD])))

def GlobalHardReset():
    Send((bytes([1, GLOBAL_HARD_RESET_CMD])))

# Opens the port if it is closed
if (ser.is_open==False):
    ser.open()
                        
# ***** EXAMPLES *****

# Before testing:
# After sending an instruction, always verify the response and take action if necessary. 
# Overload of instrctions can be a problem, put a "time.sleep()" between them and it should solve the issue.
# If an instruction is sent while executing another, the first instruction is lost and the last prevails.
# Track the settings made to avoid errors such as setting up the Joystick buttons improperly.

obcsID = 99
jportID = 10

stateOFF = 0
stateON = 1

mb2 = nor.MBx24(50, 5000000005)
obcs1 = nor.OBCS()
jport1 = nor.JPort()
rns1 = nor.RNS(31,3100000002)

# Enumerate before using any peripheral
Enumerate(mb2, obcsID, 0) 
Enumerate(rns1, obcsID, 0)


res = (Ping(mb2)) # Returns the mb2 ID and its serial number
# Example of manipulating information. Writes the full Serial Number instead of "500002"
print(str.format("ID: %02d Serial Number: %02d%02d%02d%02d%02d" % (res[0],res[1],res[2],res[3],res[4],res[5]))) 

# Prints the header and bulks for all the buttons logical states ranging from byte[2] to byte[27]
print(ReportButtons(jport1)) 

# Changing the backlit color of the MBx24
SetBacklitColor(mb2, 50, 200, 150, 100) 

# Only sets the backlit for 20 leds
for led in range(20): # Leds go from 0-63
    SetLEDBacklitColor(mb2, led, 200, 50, 100, 150) 

# Prints 1 array with all the buttons logical states
print(nor.JoystickUnpack(ReportButtons(jport1)))   

# Reports just the buttons, but breaks if joystick button 4 is pressed
while True:
    b = ReportButtons(jport1)
    if b != None:
        if len(b) != 0:
            if b[2] & 8 == 8: # Checks if joystick button 4 was pressed (00001000 = 8)
                break


ser.close()
