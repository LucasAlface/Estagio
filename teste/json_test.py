import json
import norair as nor
import main as mn

class Info():
    def __init__(self, peripheral, instruction, arguments):
        self.peripheral = peripheral
        self.instruction = instruction
        self.arguments = arguments

def JsonWrite(res, obj):
    peripheral = obj.id
    instruction = res[1]
    arguments = []
    for argument in range(2,len(res)):
        arguments.append(res[argument])
    b.append(Info(peripheral, instruction, arguments).__dict__) 

    # Criar ficheiro .json com os dados inseridos
    with open(file_name, 'w', encoding='utf8') as f: 
        json.dump(b,f,ensure_ascii=False,indent=2) 
    print('Dados guardados com sucesso')

file_name = 'arguments.json' 
b = [] 

if __name__ == '__main__':

    JsonWrite(nor.MBx24.SetBacklitColor(mn.mb2, 250, 150, 50, 100), mn.mb2)
    

    JsonWrite(nor.MBx24.Ping(mn.mb2), mn.mb2)
    
    JsonWrite(nor.MBx24.SetOutput(mn.mb2,7,1), mn.mb2)

info = []

# Leitura dos dados inseridos
with open(file_name, 'r', encoding='utf8') as f: 
    info = json.load(f)

for item in info:
    peripheral = item['peripheral']
    instruction = item['instruction']
    arguments = item['arguments']
    mn.Enviar(bytes([peripheral, instruction] + arguments[:len(arguments)]))