pairs = []
lines = []

def readFile(fileName):
	print("1. Feladat:")
	with open(fileName,"r") as f:
		for line in f:
			lines.append(line.strip())
			#print(line.strip())
		for i in range(2, len(lines), 3):
			pairs.append([lines[i-2],lines[i-1], lines[i]])
			#print(i)
			#print([lines[i-2],lines[i-1], lines[i]])

def masodikFeladat():
	print("")
	print("2. Feladat:")
	fd = pairs[0][0]
	print("Első tánc: {0}".format(fd))
	ld = pairs[len(pairs)-1][0]
	print("Utolsó tánc: {0}".format(ld))

def harmadikFeladat():
	print("")
	print("3.Feladat:")
	samba = 0
	for line in pairs:
		if (line[0] == "samba"):
			samba += 1
	print("Összesen {0} pár táncolt sambát.".format(samba))

def negyedikFeladat():
	print("")
	print("4. Feladat:")
	print("Vilma a következő táncokban szerepelt:")
	for line in pairs:
		if (line[1] == "Vilma"):
			print(line[0])

def otodikFeladat():
	print("")
	print("5. Feladat:")
	dance = input("Adja meg a tánc nevét:")
	for line in pairs:
		if (line[1] == "Vilma" and line[0] == dance):
			print("A {0} bemutatóján Vilma párja {1} volt.".format(dance,line[2]))
			return
	print("Vilma nem táncolt {0}-t.".format(dance))

def hatodikFeladat():
	print("")
	print("6. Feladat:")
	girls = set()
	boys = set()

	for line in pairs:
		girls.add(line[1])
		boys.add(line[2])
	with open("szereplok.txt", "w") as f:
		f.writelines("Lányok: "+", ".join(girls))
		f.write("\n")
		f.writelines("Fiúk: "+", ".join(boys))
		f.write("\n")
	#print(girls)

def hetedikFeladat():
	print("")
	print("7. Feladat:")
	girls = {}
	boys = {}

	for line in pairs:
		if line[1] not in girls:
			girls[line[1]] = 1
		else:
			girls[line[1]] += 1
		if line[2] not in boys:
			boys[line[2]] = 1
		else:
			boys[line[2]] += 1
	#print(girls)
	#print(boys)
	#print(max(girls.items(), key=lambda item: item[1]))
	print("A legtöbször szereplő lányok:",maxGender(girls))
	print("A legtöbször szereplő fiúk:",maxGender(boys))


	'''
	#Other way:
	for g in girls:
		if girls[g] > maxg:
			maxg = girls[g]
	for g in girls:
		if girls[g] == maxg:
			print(g)
	'''

def maxGender(gender):
	maxg = 0
	gl = []
	for g in gender:
		if gender[g] > maxg:
			gl = []
			gl.append(g)
			maxg = gender[g]
		elif maxg == gender[g]:
			gl.append(g)

	return ", ".join(gl)


def main(): 
  readFile("tancrend.txt")
  masodikFeladat() 
  harmadikFeladat()
  negyedikFeladat()
  otodikFeladat()
  hatodikFeladat()
  hetedikFeladat()

if __name__ == '__main__':
  main()  