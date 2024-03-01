import serial
import serial.tools.list_ports
import csv
import time
from colorama import Fore,Back,init
init()

def searchPort():
    portlist = serial.tools.list_ports.comports()
    if portlist == []:
        print("无法找到任何通讯端口！！！")
        return False
    for port in portlist:
        if "2DD6:27F4" in port.hwid:
            return port.name


if __name__ == "__main__":
    while True:
        input("任意键盘输入以继续...")
        portResult = searchPort()
        if portResult == False:
            continue
        else:
            try:
                scanner = serial.Serial(portResult,115200)
            except:
                print("端口占用！！！")
                continue
        with open('TM5.CSV','r') as csvfile:
            reader = csv.reader(csvfile)
            header = next(reader)#省略第一行的表头
            for row in reader:
                print("==============================当前测试项：{}=========================".format(row[0]))
                #print("发送数据input1:{}".format(row[1]))
                try:
                    input1 = row[1].encode().decode("unicode_escape").encode("cp1252")
                    scanner.write(input1)
                    print("发送数据input1:{}".format(input1))
                except:
                    print("端口关闭")
                    continue
                time.sleep(1)
                if row[2] !="":
                    input2 = row[2].encode().decode("unicode_escape").encode("cp1252")
                    print("发送数据input2:{}".format(input2))
                    scanner.write(input2)
                    time.sleep(1)
                if row[3] != "":
                    input3 = row[3].encode().decode("unicode_escape").encode("cp1252")
                    print("发送数据input3:{}".format(input3))
                    scanner.write(input3)
                    time.sleep(1)
                ret = scanner.read_all()
                print("返回数据output:{}".format(ret))
                if row[4].encode().decode("unicode_escape").encode("cp1252") == ret or row[4] == "":
                #if ret.decode("cp1252").encode("unicode_escape") == row[4].encode():
                    print(Fore.GREEN + "测试成功" + Fore.RESET)
                else:
                    print(Fore.RED + "测试失败" + Fore.RESET)
            scanner.close()

