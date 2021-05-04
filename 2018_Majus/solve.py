

data = []

def readFile():
  with open("ajto.txt", "r") as file:
    for line in file.readlines():
      line = line.strip()
      data.append(line.split())



def elso_feladat():
  print("elso feladat:")
  readFile()
  #print(data)


def masodik_feladat():
  print("masodik feladat:")
  for i in data:
    if i[3] == "be":
      print("Elso be azonositoja:", i[2])
      break
  for i in data[::-1]:
    if i[3] == "ki":
      print("Elso ki azonositoja:", i[2])
      break

def harmadik_feladat():
  print("harmadik feladat:")
  d = {}
  for i in data:
    if int(i[2]) not in d:
      d[int(i[2])] = 1
    else:
      d[int(i[2])] += 1
  
  with open("athaladas.txt", "w") as file:
    print("writing to file...")
    for i in sorted(d.keys()):
      file.write(str(i) + " " + str(d[i]) + "\n")
      #print(i,d[i])



def negyedik_feladat():
  print("negyedik feladat:")
  tmp = []
  for i in data:
    if i[3] == "be":
      tmp.append(i[2])
    else:
      tmp = [item for item in tmp if item != i[2]]
  print(" ".join(tmp))

def otodik_feladat():
  print("otodik_feladat")
  cnt = 0
  cmax = 0
  cmax_time = ""
  for i in data:
    if i[3] == "be":
      cnt += 1
    else:
      cnt -= 1

    if cnt > cmax:
      cmax = cnt
      cmax_time = i[0]+":"+i[1]

  print("A legtobben ", cmax_time, "idopontban voltak bent ami ", cmax, "szemely")


def hatodik_feladat():
  print("hatodik feladat:")
  return input("adjon meg egy azonositot:")


def hetedik_feladat(azon):
  tmp = []
  for i in data:
    if i[2] == azon:
      tmp.append(i[0]+":"+i[1])
  for i in range(0,len(tmp),2):
    if i+1 != len(tmp):
      print(tmp[i] + " - " + tmp[i+1])
    else:
      print(tmp[i] + " - ")



def nyolcadik_feladat(azon):
  inside = False
  entered = ""
  time = 0
  for i in data:
    if i[2] == azon:
      if i[3] == "be":
        entered = i[0]+":"+i[1]
        inside = True
      else:
        inside = False
        ih = int(entered.split(":")[0])
        im = int(entered.split(":")[1])
        entered = ""
        lh = int(i[0])
        lm = int(i[1])

        m = calcTimeDiff(ih, im, lh, lm)
        time = time + m

  if inside:
    ih = int(entered.split(":")[0])
    im = int(entered.split(":")[1])
    lh = 15
    lm = 0
    m = calcTimeDiff(ih, im, lh, lm)
    time = time + m


  print("A(z)", azon, "személy összesen", time, "percet volt bent, a megfigyelés végén", "" if inside else "nem" ,"a társalgóban volt.")


def calcTimeDiff(ih, im, lh, lm):
  m = 0
  if (lh - ih > 1):
    m = 60 * (lh - ih - 1)
  if lm >= im:
    m = m + (lm - im)
  else:
    m = m + (60 - (im - lm))
  
  return m


elso_feladat()
masodik_feladat()
harmadik_feladat()
negyedik_feladat()
otodik_feladat()
azon = hatodik_feladat()
#print(azon)
hetedik_feladat(azon)
nyolcadik_feladat(azon)




