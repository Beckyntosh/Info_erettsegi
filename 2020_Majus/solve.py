lines = []

def readFile(fileName):
  with open(fileName, "r") as f:
    for line in f:
      lines.append(line.split(" "))

def format_time(line):
  return line[1][0:2]+":"+line[1][2:4]

def masodikFeladat():
  city_code = input("Kérem adjon meg egy várost: ") 
  print(city_code)
  for line in reversed(lines):
    if (line[0] == city_code):
      ido = format_time(line)
      varos = line[0]
      print("Második Feladat: A {0} városban az utolsó mérés ideje {1} volt.".format(varos, ido))
      break

def min_hom(t):
  cmin = t[0]
  for line in t:
    if(line[3].rstrip() < cmin[3].rstrip()):
      cmin = line
  return cmin

def max_hom(t):
  cmax = t[0]
  for line in t:
    if(line[3].rstrip() > cmax[3].rstrip()):
      cmax = line
  return cmax

def harmadikFeladat():
  cmin = min_hom(lines)
  cmax = max_hom(lines)
  print("Harmadik Feladat:")
  print("A minimum hőmérséklet {0} Celsius volt {1} városban {2} órakkor {3} szélerőséggel ".format(cmin[3].rstrip(), cmin[0], format_time(cmin), cmin[2]))
  print("A maximum hőmérséklet {0} Celsius volt {1} városban {2} órakkor {3} szélerőséggel ".format(cmax[3].rstrip(), cmax[0], format_time(cmax), cmax[2]))

def negyedikFeladat():
  print("Negyedik Feladat: ")
  szelcsend = []
  for line in lines:
    if line[2] == "00000":
      szelcsend.append(line)
  if len(szelcsend) == 0:
    print("Nem volt szélcsend a mérések idején")
  else:
    for i in szelcsend:
      print("Hőmérséklet {0} Celsius volt, {1} városban {2}, órakkor {3} szélerőséggel ".format(i[3].rstrip(), i[0], format_time(i), i[2]))

def getHour(time):
  return int(time[0:2])

def kozepHom(t):
  cnt = 0
  dic = {}
  for i in t:
    if getHour(i[1]) == 1 or getHour(i[1]) == 7 or getHour(i[1]) == 13 or getHour(i[1]) == 19:
      if getHour(i[1]) not in dic:
        dic[getHour(i[1])] = [int(i[3].rstrip())]
      else:
        tmp = dic[getHour(i[1])]
        tmp.append(int(i[3].rstrip()))
        dic[getHour(i[1])] = tmp
   
  #for i in dic:
  #  print(i, dic[i])

  if 1 in dic and 7 in dic and 13 in dic and 19 in dic:
    cnt = 0
    lcnt = 0
    for i in dic:
      lcnt = lcnt + len(dic[i])
      for j in dic[i]:
        cnt += j
    return round(cnt/lcnt)
  else:
    return "NA"
    
def ingadozas(t):
  return int(max_hom(t)[3].rstrip())-int(min_hom(t)[3].rstrip())


def getByCities():
  dic = {}
  for line in lines:
    if line[0] not in dic:
      dic[line[0]] = [line]
    else:
      tmp = dic[line[0]] 
      tmp.append(line)
      dic[line[0]] = tmp
  return dic

def otodikFeladat():
  print("5. Feladat:")
  for v in getByCities():
    print("{0} középhőmérséklet: {1}; Hőmérséklet-ingadozás: {2}".format(v, kozepHom(dic[v]), ingadozas(dic[v])))


def getSzelerosseg(e):
  return "#"*int(e[2][3:5])

def dataBuilder(t):
  li = []
  for i in t:
    li.append(format_time(i) + " " + getSzelerosseg(i) + "\n")
  return li

def hatodikFeladat():
  print("6. Feladat:")
  cities = getByCities()
  for c in cities:
    print("Writing " + c + " to file")
    f = open(c+".txt","w")
    f.write(c+"\n")
    f.writelines(dataBuilder(cities[c]))
    print(c + ": DONE")
    f.close()

def main(): 
  readFile("tavirathu13.txt")
  masodikFeladat() 
  harmadikFeladat()
  negyedikFeladat()
  otodikFeladat()
  hatodikFeladat()

if __name__ == '__main__':
  main()  
