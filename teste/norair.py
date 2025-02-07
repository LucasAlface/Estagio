

class MBx24:
    def __init__(self, id, serialNumber):
        self.id = id
        self.serialNumber = serialNumber
    
    # Função para enumerar um periférico
    def Enumerate(self, s):
        serialNumber = str(self.serialNumber)
        n1 = (int)(serialNumber[0:2])
        n2 = (int)(serialNumber[2:4])
        n3 = (int)(serialNumber[4:6])
        n4 = (int)(serialNumber[6:8])
        n5 = (int)(serialNumber[8:10])
        if (s == 0):
            s = n1
        return bytes([99, 7, n1, n2, n3, n4, n5, s])
    
    # Função para fazer ping
    def Ping(self):
        return (bytes([self.id, 6]))

    # Função para mudar a cor de todos os leds
    def SetBacklitColor(self, r, g, b , w):
        return(bytes([self.id, 41, r, g, b, w]))    

    # Função para mudar a cor de um led
    def SetLEDBacklitColor(self, led, r, g, b, w):
        return(bytes([self.id, 42, led, r, g, b, w])) 

    # Função para ligar/desligar outputs
    def SetOutput(self, output, estado):
        return(bytes([self.id, 20, output, estado])) 
    
    #Função para alterar o estado dos outputs
    def ToggleOutput(self, output):
        return(bytes([self.id, 25, output])) 
    
    def BulkSetOutput(self, s1, s2, s3, s4):
        return(bytes([self.id, 21, s1, s2, s3, s4])) 
    
    # Função para definir o tipo de outpuyt
    def SetOutputType(self, output, type, flashPeriod, inverted):
        return (bytes([self.id, 30, output, type, flashPeriod, inverted]))
    
    # Função para definir VICe connectors
    def SetVICe(self, connector, botJoystick):
        return (bytes([self.id, 75, connector, botJoystick]))
    
    # Função para conectar inputs com joystick
    def SetButtonNumber(self, connector, botJoystick):
        return (bytes([self.id, 80, connector, botJoystick]))
    
    # Função para definir o primeiro botão de joystick
    def SetFirstButtonNumber(self, numButton):
        return (bytes([self.id, 85, numButton]))
    
    def SetDisplayDigit(self, displayNumber, digitNumber, characterConstructor):
        return (bytes([self.id, 50, displayNumber, digitNumber, characterConstructor]))
    
    def ReportEnconder(self):
        return (bytes([self.id, 48]))
    
    def ReportInputConnectors(self):
        return (bytes([self.id, 55]))
    
    def SoftReset(self):
        return (bytes([self.id, 4]))
    
    def HardReset(self):
        return (bytes([self.id, 2]))
    

    

class OBCS:
    def __init__(self):
        self.id = 99

    def Ping(self):
        return (bytes([self.id, 6]))
    
    def HardReset(self):
        return (bytes([self.id, 2]))
    
    def ReportEnumeration(self):
        return (bytes([self.id, 18]))
    

class JPort:
    def __init__(self):
        self.id = 10
       
    def Ping(self):
        return (bytes([self.id, 6]))

    def HardReset(self):
        return (bytes([self.id, 2]))

    def SoftReset(self):
        return (bytes([self.id, 4]))

    def ProgramButton(self, joystickButton, buttonType):
        return (bytes([self.id, 17, joystickButton, buttonType]))

    def ReportButtons(self):
        return (bytes([self.id, 12]))

    def ReportEnumeration(self):
        return (bytes([self.id, 18]))

class RNS:
    def __init__(self, id, serialNumber):
        self.id = id
        self.serialNumber = serialNumber

    def Ping(self):
        return (bytes([self.id, 6]))

    # Função para enumerar um periférico
    def Enumerate(self, s):
        serialNumber = str(self.serialNumber)
        n1 = (int)(serialNumber[0:2])
        n2 = (int)(serialNumber[2:4])
        n3 = (int)(serialNumber[4:6])
        n4 = (int)(serialNumber[6:8])
        n5 = (int)(serialNumber[8:10])
        if (s == 0):
            s = n1
        return bytes([99, 7, n1, n2, n3, n4, n5, s])

    def HardReset(self):
        return (bytes([self.id, 2]))

    def SoftReset(self):
        return (bytes([self.id, 4]))

    def ChangeButtonNumber(self, connector, joystickButton):
        return (bytes([self.id, 80, connector, joystickButton]))

    def ReportFrequencies(self):
        return (bytes([self.id, 72]))

    def ReportXPDR_SquawkCode(self):
        return (bytes([self.id, 73]))

    def SetActiveFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        if instrument == 2:
            digit5 = 0
            digit6 = 0
        return (bytes([self.id, 20, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    # Função para mudar a cor de todos os leds
    def SetBacklitColor(self, r, g, b , w):
        return(bytes([self.id, 41, r, g, b, w])) 

    def SetDecimalIncrement(self, instrument, digit1, digit2, digit3):
        if instrument == 2:
            digit3 = 0
        return (bytes([self.id, 23, instrument, digit1, digit2, digit3]))

    def SetDisplayLuminosity(self, luminosity):
        return (bytes([self.id, 40, luminosity]))

    def SetIntegerIncrement(self, instrument, digit1, digit2, digit3):
        if instrument == 2:
            digit3 = 0
        return (bytes([self.id, 22, instrument, digit1, digit2, digit3]))

    # Função para mudar a cor de um led
    def SetLEDBacklitColor(self, led, r, g, b, w):
        return(bytes([self.id, 42, led, r, g, b, w])) 

    def SetMaximumFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        return (bytes([self.id, 25, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    def SetMinimumFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        return (bytes([self.id, 24, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    def SetStandByFrequency(self, instrument, digit1, digit2, digit3, digit4, digit5, digit6):
        return (bytes([self.id, 21, instrument, digit1, digit2, digit3, digit4, digit5, digit6]))

    def SetXPDR_DecimalIncrement(self, digit1, digit2):
         return (bytes([self.id, 33, digit1, digit2]))

    def SetXPDR_IntegerIncrement(self, digit1, digit2):
         return (bytes([self.id, 32, digit1, digit2]))

    def SetXPDR_MaximumSquawk(self, digit1, digit2, digit3, digit4):
        return (bytes([self.id, 35, digit1, digit2, digit3, digit4]))

    def SetXPDR_MinimumSquawk(self, digit1, digit2, digit3, digit4):
        return (bytes([self.id, 34, digit1, digit2, digit3, digit4]))

    def SetXPDR_SquawkCode(self, digit1, digit2, digit3, digit4):
        return (bytes([self.id, 38, digit1, digit2, digit3, digit4]))

