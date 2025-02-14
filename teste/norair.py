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
This file contains the classes, with their respective constructors
and functions, of the products present in the Norair Labs SDK.
The functions recieve the request structure from the main.py file
and returns the bytearray necessary to write and/or read the request
to posteriorly recieve the response and/or a result intended from the
instruction
"""
import numpy as num

class MBx24:

    # Commands
    MB_ENUMERATE_CMD = 7
    MB_PING_CMD = 6
    MB_SET_BACKLIT_COLOR_CMD = 41
    MB_SET_LED_BACKLIT_COLOR_CMD = 42
    MB_SET_OUTPUT_CMD = 20
    MB_TOGGLE_OUTPUT_CMD = 25
    MB_BULK_SET_OUTPUT_CMD = 21
    MB_SET_OUTPUT_TYPE_CMD = 30
    MB_SET_VICE_TYPE_CMD = 17
    MB_SET_VICE_CMD = 75
    MB_SET_BUTTON_NUMBER_CMD = 80
    MB_SET_FIRST_BUTTON_NUMBER_CMD = 85
    MB_SET_DISPLAY_DIGIT_CMD = 50
    MB_REPORT_ENCODER_CMD = 48
    MB_REPORT_INPUT_CONNECTORS_CMD = 55
    MB_SOFT_RESET_CMD = 4
    MB_HARD_RESET_CMD = 2

    def __init__(self, id, serialNumber):
        # Constructor with the id and Serial Number of the peripheral as arguments
        self.id = id
        self.serialNumber = serialNumber
    

    def Enumerate(self, port, s):
        # Enumerates the peripheral and inserts it in the given port enumeration table
        # "port" - checks what port the peripheral will be enumarated (C-Port or J-Port)
        # "s" - is the new peripheral ID (s = 0 if you want it to stay the same)
        serialNumber = str(self.serialNumber) # Get the SN from the peripheral
        # Divide the SN into pairs
        n1 = (int)(serialNumber[0:2])
        n2 = (int)(serialNumber[2:4])
        n3 = (int)(serialNumber[4:6])
        n4 = (int)(serialNumber[6:8])
        n5 = (int)(serialNumber[8:10])
        # Check if the ID stays the same
        if (s == 0):
            s = n1
        return bytes([port, self.MB_ENUMERATE_CMD, n1, n2, n3, n4, n5, s])
    
    def Ping(self):
        # Returns the serial number as proof of life
        return (bytes([self.id, self.MB_PING_CMD]))

    def SetBacklitColor(self, r, g, b, w):
        # Sets the backlit color
        # The arguments are the color codes in RGBW for each letter
        return(bytes([self.id, self.MB_SET_BACKLIT_COLOR_CMD, r, g, b, w]))    

    def SetLEDBacklitColor(self, led, r, g, b, w):
        # Sets the backlit color for a specific led
        # "led" - number of the LED you want to set (0-63)
        # The rest of the arguments are the color codes in RGBW
        return(bytes([self.id, self.MB_SET_LED_BACKLIT_COLOR_CMD, led, r, g, b, w])) 

    def SetOutput(self, output, state):
        # Sets the logic state of a given output 
        # "output" - output number you want to set (1-32)
        # "state" - sets the logical state of the ouput (0 = off ; 1 = on)
        return(bytes([self.id, self.MB_SET_OUTPUT_CMD, output, state])) 
    
    def ToggleOutput(self, output):
        # Inverts the logic state of a given output
        # The argument "output" is the output you want to toggle
        return(bytes([self.id, self.MB_TOGGLE_OUTPUT_CMD, output])) 
    
    def BulkSetOutput(self, s1, s2, s3, s4):
        # Sets all the outputs logic states at the same time
        # First Output Bank s1 = outputs 1-8 
        # Second Output Bank s2 = outputs 9-16 
        # Third Output Bank s3 = outputs 17-24 
        # Fourth Output Bank s4 = outputs 25-32
        # The arguments are translated to a byte where "1" means ON and "0" means OFF 
        return(bytes([self.id, self.MB_BULK_SET_OUTPUT_CMD, s1, s2, s3, s4])) 
    
    def SetOutputType(self, output, type, flashPeriod, inverted):
        # Sets the behaviour of a given output
        # "output" - output number you want to set (1-32)
        # "type" - sets the type of the output (0 - Normal ; 1 - Flashing)
        # "flashPeriod" - sets the flashing period of the output, multiplying the given number by ~300ms
        # "inverted" - "0" to stay normal "1" to invert the logical state
        return (bytes([self.id, self.MB_SET_OUTPUT_TYPE_CMD, output, type, flashPeriod, inverted]))
    
    def SetVICeType(self, jPortID, buttonNumber, buttonType):
        # Sets the behavior of a VICe joystick button
        # *** A VICe must be created before calling this instruction ***
        # "jPortID" - we need the jPortID to send the request of the instrction (jPortID = 10)
        # "buttonNumber" - Joystick VICe button number you want to set (1-200)
        # "buttonType" - Recieves the button type of the Joystick Button associated with the VICe.
        # The program does the correspondence found in the table below:
        # Action button type declared: |  0   |   1    |       2       |        3        |  
        # Behavior:                    | Push | Toggle | Inverted Push | Inverted Toggle |   
        # buttonType value:            |  0   |   3    |       2       |        1        |   

        # Giving the correpondent button type to the VICe
        if buttonType == 1:
            buttonType = 3
        elif buttonType == 3:
            buttonType = 1
        return (bytes([jPortID, self.MB_SET_VICE_TYPE_CMD, buttonNumber, buttonType]))
    
    def SetVICe(self, connector, joystickButton):
        # Sets a VICe connector or destroys it if joystickButton = 0
        # "connector" - VICe connector number (1-32). The selected connector must have the same number of the connector to associate to.
        # "joystickButton" - JoyStick button associated with the VICe connector (1-200). The selected button must be exclusive to the VICe
        return (bytes([self.id, self.MB_SET_VICE_CMD, connector, joystickButton]))
    
    def SetButtonNumber(self, connector, joystickButton):
        # Sets the joystick button number to a physical connector
        # "connector" - Connector number you want to set (1-32)
        # "joystickButton" - Assigned JoyStick button number (1-200)
        return (bytes([self.id, self.MB_SET_BUTTON_NUMBER_CMD, connector, joystickButton]))
    
    def SetFirstButtonNumber(self, buttonNum):
        # Sets the first JoyStick button to be assigned to the 32 connectors
        # When executed, all input connectors are re-assgined to their new values
        # *** Should only be executed before execueting a SetButtonNumber() ***
        # Does not affect VICe connectors
        # Default range: 50-81
        # "buttonNum" - First JoyStick button number the be assigned
        return (bytes([self.id, self.MB_SET_FIRST_BUTTON_NUMBER_CMD, buttonNum]))
    
    def SetDisplayDigit(self, displayNumber, digitNumber, characterConstructor):
        # Sets the display digit
        # "displayNumber" - (1-4)
        # "digitNumber" - (1-4)
        # "characterConstructor" - A character constructor is a byte with values for a 7-segment scheme where each bit corresponds to a segment.
        # Bit Position: | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
        # Segment:     | dp | G | F | E | D | C | B | A |
        return (bytes([self.id, self.MB_SET_DISPLAY_DIGIT_CMD, displayNumber, digitNumber, characterConstructor]))
    
    def ReportEnconder(self):
        # Returns the MBx24 encoders counters representation in a bulk
        return (bytes([self.id, self.MB_REPORT_ENCODER_CMD]))
    
    def ReportInputConnectors(self):
        # Reports the input connectors logic states in multiple 8-bit clusters
        return (bytes([self.id, self.MB_REPORT_INPUT_CONNECTORS_CMD]))
    
    def SoftReset(self):
        # Resets all settings to the factory deafaults
        return (bytes([self.id, self.MB_SOFT_RESET_CMD]))
    
    def HardReset(self):
        # Resets all settings to the factory deafaults and the peripheral must be re-enumerated
        return (bytes([self.id, self.MB_HARD_RESET_CMD]))   

class OBCS:

    OBCS_PING_CMD = 6
    OBCS_HARD_RESET_CMD = 2
    OBCS_REPORT_ENUMERATION_CMD = 18

    def __init__(self):
        self.id = 99

    def Ping(self):
        # Returns the OBCS welcome message as proof of life ("99present")
        return (bytes([self.id, self.OBCS_PING_CMD]))
    
    def HardReset(self):
        # Hard Resets the OBCS and the enumerations are lost. Does not affect peripherals
        return (bytes([self.id, self.OBCS_HARD_RESET_CMD]))
    
    def ReportEnumeration(self):
        # Returns the number of peripherals and ID's enumerated in the OBCS
        return (bytes([self.id, self.OBCS_REPORT_ENUMERATION_CMD]))
    

class JPort:

    JPORT_PING_CMD = 6
    JPORT_HARD_RESET_CMD = 2
    JPORT_SOFT_RESET_CMD = 4
    JPORT_PROGRAM_BUTTON_CMD = 17
    JPORT_REPORT_BUTTONS_CMD = 12
    JPORT_REPORT_ENUMERATION_CMD = 18

    def __init__(self):
        self.id = 10
       
    def Ping(self):
        # Returns the J-Port welcome message as proof of life ("10present")
        return (bytes([self.id, self.JPORT_PING_CMD]))

    def HardReset(self):
        # Hard Resets the J-Port and the enumerations are lost. Does not affect peripherals
        return (bytes([self.id, self.JPORT_HARD_RESET_CMD]))

    def SoftReset(self):
        # All buttons return to their factory default values. Does not affect periphreals, but a new buttons configuration must be made.
        # *** Execute a Soft Reset BEFORE the set up of joystick buttons
        return (bytes([self.id, self.JPORT_SOFT_RESET_CMD]))

    def ProgramButton(self, joystickButton, buttonType):
        # Sets the behavior of a button
        # "joystickButton" - The Joystick button sellected (1-200)
        # "buttonType" - Behavior of the button (1- Push ; 2- Toggle ; 3- Inverted Push ; 4- Inverted Toggle)
        return (bytes([self.id, self.JPORT_PROGRAM_BUTTON_CMD, joystickButton, buttonType]))

    def ReportButtons(self):
        # Reports the logical states of the Joystick Buttons in 26 bulks
        return (bytes([self.id, self.JPORT_REPORT_BUTTONS_CMD]))

    def ReportEnumeration(self):
        # Returns the number of peripherals and ID's enumerated in the J-Port
        return (bytes([self.id, self.JPORT_REPORT_ENUMERATION_CMD]))

class RNS:

    RNS_PING_CMD = 6
    RNS_ENUMERATE_CMD = 7 
    RNS_SOFT_RESET_CMD = 4
    RNS_HARD_RESET_CMD = 2
    RNS_CHANGE_BUTTON_NUMBER_CMD = 80
    RNS_REPORT_FREQUENCIES_CMD = 72
    RNS_REPORT_XPDR_SQUAWK_CODE_CMD = 73
    RNS_SET_ACTIVE_FREQUENCY_CMD = 20
    RNS_SET_BACKLIT_COLOR_CMD = 41
    RNS_SET_DECIMAL_INCREMENT_CMD = 23
    RNS_SET_DISPLAY_LUMINOSITY_CMD = 40
    RNS_SET_INTEGER_INCREMENT_CMD = 22
    RNS_SET_LED_BACKLIT_COLOR_CMD = 42
    RNS_SET_MAXIMUM_FREQUENCY_CMD = 25
    RNS_SET_MINIMUM_FREQUENCY_CMD = 24
    RNS_SET_STANDBY_FREQUENCY_CMD = 21
    RNS_SET_XPDR_DECIMAL_INCREMENT_CMD = 33
    RNS_SET_XPDR_INTEGER_INCREMENT_CMD = 32
    RNS_SET_XPDR_MAXIMUM_SQUAWK_CMD = 35
    RNS_SET_XPDR_MINIMUM_SQUAWK_CMD = 34
    RNS_SET_XPDR_SQUAWK_CODE_CMD = 38

    def __init__(self, id, serialNumber):
        self.id = id
        self.serialNumber = serialNumber
       
    def Ping(self):
        # Returns the serial number as proof of life
        return (bytes([self.id, 6]))

    def Enumerate(self, port, s):
        # Enumerates the peripheral and inserts it in the given port enumeration table
        # "port" - checks what port the peripheral will be enumarated (C-Port or J-Port)
        # "s" - is the new peripheral ID (s = 0 if you want it to stay the same)
        serialNumber = str(self.serialNumber) # Get the SN from the peripheral
        # Divide the SN into pairs
        n1 = (int)(serialNumber[0:2])
        n2 = (int)(serialNumber[2:4])
        n3 = (int)(serialNumber[4:6])
        n4 = (int)(serialNumber[6:8])
        n5 = (int)(serialNumber[8:10])
        # Check if the ID stays the same
        if (s == 0):
            s = n1
        return bytes([port, self.RNS_ENUMERATE_CMD, n1, n2, n3, n4, n5, s])

    def HardReset(self):
        # Resets all settings to the factory deafaults and the peripheral must be re-enumerated
        return (bytes([self.id, self.RNS_HARD_RESET_CMD]))

    def SoftReset(self):
        # Resets all settings to the factory deafaults
        return (bytes([self.id, self.RNS_SOFT_RESET_CMD]))

    def ChangeButtonNumber(self, connector, joystickButton):
        # Sets a joystick button to an encoder center push-button
        # "connector" - Encoder center-push button (1-4)
        # "joystickButton" - Joystick button to be associated (1-200)
        # Default Values: COMM NAV ADF XPDR
        # Connector:      | 1 | 2 | 3 | 4 |
        # Joystick Button:| 1 | 2 | 3 | 4 |
        return (bytes([self.id, self.RNS_CHANGE_BUTTON_NUMBER_CMD, connector, joystickButton]))

    def ReportFrequencies(self):
        # Reports the frequencies of all instruments in 27 bulks
        return (bytes([self.id, self.RNS_REPORT_FREQUENCIES_CMD]))

    def ReportXPDR_SquawkCode(self):
        # Returns the transponder squawk code value
        return (bytes([self.id, self.RNS_REPORT_XPDR_SQUAWK_CODE_CMD]))

    def SetActiveFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        # Sets the active frequency of a given instrument
        # "instrument" - instrument selected to set active frequency (0- NAV ; 1- COMM ; 2- ADF)
        # "digits" - each digit of the frequency intended to be set. ADF only takes 4 digits, the last 2 are ignored
        # Default Values: Instrument  Frequency  Minimum  Maximum
        #                 |   NAV   |  108.000 |  0.000 | 999.999 |
        #                 |   COMM  |  118.000 |  0.000 | 999.999 |
        #                 |   ADF   |  0000    |  0000  | 9999    |
        return (bytes([self.id, self.RNS_SET_ACTIVE_FREQUENCY_CMD, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    def SetBacklitColor(self, r, g, b , w):
        # Sets the backlit color
        # The arguments are the color codes in RGBW for each letter
        return(bytes([self.id, self.RNS_SET_BACKLIT_COLOR_CMD, r, g, b, w])) 

    def SetDecimalIncrement(self, instrument, digit1, digit2, digit3):
        # Sets the increment of the decimal digits of the NAV and COMM and the lower 2 digits on the ADF
        # "instrument" - instrument selected to set increment (0- NAV ; 1- COMM ; 2- ADF)
        # "digits" - each digit of the increment intended to be set. ADF only takes 2 digits, the last is ignored
        return (bytes([self.id, self.RNS_SET_DECIMAL_INCREMENT_CMD, instrument, digit1, digit2, digit3]))

    def SetDisplayLuminosity(self, luminosity):
        # Sets the display's luminosity
        # "luminosity" - Level of luminosity (0-10)
        return (bytes([self.id, self.RNS_SET_DISPLAY_LUMINOSITY_CMD, luminosity]))

    def SetIntegerIncrement(self, instrument, digit1, digit2, digit3):
        # Sets the increment of the integer digits of the NAV and COMM and the upper 2 digits on the ADF
        # "instrument" - instrument selected to change increment (0- NAV ; 1- COMM ; 2- ADF)
        # "digits" - each digit of the increment intended to be set. ADF only takes 2 digits, the last is ignored
        return (bytes([self.id, self.RNS_SET_INTEGER_INCREMENT_CMD, instrument, digit1, digit2, digit3]))

    def SetLEDBacklitColor(self, led, r, g, b, w):
        # Sets the backlit color for a specific led
        # "led" - number of the LED you want to set (0-63)
        # The rest of the arguments are the color codes in RGBW
        return(bytes([self.id, self.RNS_SET_LED_BACKLIT_COLOR_CMD, led, r, g, b, w])) 

    def SetMaximumFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        # Sets the maximum frequency to the given instrument
        # "instrument" - instrument selected to set maximum frequency (0- NAV ; 1- COMM ; 2- ADF)
        # "digits" - each digit of the frequency intended to be set. ADF only takes 4 digits, the last 2 are ignored
        # In the COMM or NAV the maximum frequencies are related to the minimum frequencies and the increment
        # Example: 
        # If these are your parameters
        # Minimum Frequency: 108.000
        # Target Maximum Frequency: 118.000
        # Decimal Increment: 50
        # Steps:
        # Delta = Maximum Frequency – Minimum Frequency Delta = 118000 - 108000 = 10000

        # Steps = (Delta / Increment) - 1 Steps = (10000 / 50) - 1 = 199

        # Range = Steps * Increment Range = 199 * 50 = 9950

        # Result = Minimum Frequency + Range Result = 108000 + 9950 = 117950

        # Result: The maximum frequency is 117.950. (not 118.000)

        # Knowing that the increment and the target maximum frequency are divisible, you can also do this:
        # Target Maxmimum Frequency - Decimal Increment
        # 118000 - 50 = 117950
        return (bytes([self.id, self.RNS_SET_MAXIMUM_FREQUENCY_CMD, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    def SetMinimumFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        # Sets the minimum frequency to the given instrument
        # "instrument" - instrument selected to set minimum frequency (0- NAV ; 1- COMM ; 2- ADF)
        # "digits" - each digit of the frequency intended to be set. ADF only takes 4 digits, the last 2 are ignored
        return (bytes([self.id, self.RNS_SET_MINIMUM_FREQUENCY_CMD, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    def SetStandByFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        # Sets the stand-by frequency of a given instrument
        # "instrument" - instrument selected to set stand-by frequency (0- NAV ; 1- COMM ; 2- ADF)
        # "digits" - each digit of the frequency intended to be set. ADF only takes 4 digits, the last 2 are ignored
        return (bytes([self.id, self.RNS_SET_STANDBY_FREQUENCY_CMD, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    def SetXPDR_DecimalIncrement(self, digit1, digit2):
         # Sets the increment of the lower 2 digits of the transpoder
         # "digits" - each digit of the increment intended to be set
         return (bytes([self.id, self.RNS_SET_XPDR_DECIMAL_INCREMENT_CMD, digit1, digit2]))

    def SetXPDR_IntegerIncrement(self, digit1, digit2):
         # Sets the increment of the upper 2 digits of the transpoder
         # "digits" - each digit of the increment intended to be set
         return (bytes([self.id, self.RNS_SET_INTEGER_INCREMENT_CMD, digit1, digit2]))

    def SetXPDR_MaximumSquawk(self, digit1, digit2, digit3, digit4):
        # Sets the transpoder maximum squawk value (0-9999)
        # "digits" - each digit of the squawk value intended to be set
        return (bytes([self.id, self.RNS_SET_XPDR_MAXIMUM_SQUAWK_CMD, digit1, digit2, digit3, digit4]))

    def SetXPDR_MinimumSquawk(self, digit1, digit2, digit3, digit4):
        # Sets the transpoder minimum squawk value (0-9999)
        # "digits" - each digit of the squawk value intended to be set
        return (bytes([self.id, self.RNS_SET_XPDR_MINIMUM_SQUAWK_CMD, digit1, digit2, digit3, digit4]))

    def SetXPDR_SquawkCode(self, digit1, digit2, digit3, digit4):
        # Sets the transpoder squawk value (0-9999)
        # "digits" - each digit of the squawk value intended to be set
        return (bytes([self.id, self.RNS_SET_XPDR_SQUAWK_CODE_CMD, digit1, digit2, digit3, digit4]))


def JoystickUnpack(data):
    # Returns an array off 200 digits with all of the joystick buttons logical states
    # Unpacks the bits of the 26 bulks recieved by the ReportButtons() function using numpy
    # "data" - The returned array of the ReportButtons() function
    # You can install numpy with "pip install numpy"
    res = data
    r = bytearray(200)
    r = num.array([res[2], res[3], res[4], res[5], res[6], res[7],
    res[8], res[9], res[10], res[11], res[12], res[13], res[14], 
    res[15], res[16], res[17], res[18], res[19], res[20], res[21], 
    res[22], res[23], res[24], res[25], res[26], res[27]], dtype = num.uint8)  
   
    return num.unpackbits(r)

