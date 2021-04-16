from io import open

foglaltsag = []
kategoria = []
'''f = open("foglaltsag.txt", "r")
k = open("kategoria.txt", "r")
foglaltsag = f.readlines()
kategoria = k.readlines()'''

def readFile(fileName1, fileName2):
	print("")
	print("1. Feladat: ")
	print("Beolvasás")

	with open(fileName1, "r") as f:
		for line in f:
			foglaltsag.append(line.strip())

	with open(fileName2, "r") as k:
		for line in k:
			kategoria.append(line.strip())
			#print(line)

def masodikFeladat():
	print("")
	print("2. Feladat:")

	row = int(input("Kérem adja meg a sor számát: "))
	column = int(input("Kérem adja meg a szék számát: "))

	if (foglaltsag[row-1][column-1] == "x"):
		print("A hely foglalt.")
	else:
		print("A hely szabad.")

def harmadikFeladat():
	print("")
	print("3. Feladat: ")
	sold = 0
	total = 15*20

	for line in foglaltsag:
		for chair in line:
			if chair == "x":
				sold += 1
	#print(sold)
	r = round(sold/total*100)
	print("Az előadásra eddig {0} jegyet adtak el, ez a nézőtér {1}%-a.".format(sold,r))

def negyedikOtodikFeladat():
	print("")
	print("4. Feladat: ")
	k1 = 0
	k2 = 0
	k3 = 0
	k4 = 0
	k5 = 0

	for i,lines in enumerate(foglaltsag):
		for j,chair in enumerate(lines):
			if chair == "x":
				#print(kategoria[i][j])
				if kategoria[i][j] == "1":
					k1 += 1
				if kategoria[i][j] == "2":
					k2 += 1
				if kategoria[i][j] == "3":
					k3 += 1
				if kategoria[i][j] == "4":
					k4 += 1
				if kategoria[i][j] == "5":
					k5 += 1

	if k1 >= k2 and k1 >= k3 and k1 >= k4 and k1 >= k5:
		print("Kategória 1",k1)
	elif k2 >= k1 and k2 >= k3 and k2 >= k4 and k2 >= k5:
		print("Kategória 2",k2)
	elif k3 >= k1 and k3 >= k2 and k3 >= k4 and k3 >= k5:
		print("Kategória 3",k3)
	elif k4 >= k1 and k4 >= k2 and k4 >= k3 and k4 >= k5:
		print("Kategória 4",k4)
	else:
		print("kategória 5",k5)

	print("")
	print("5. Feladat: ")
	s = k1*5000+k2*4000+k3*3000+k4*2000+k5*1500
	print("A bevétel összege: {0} HUF.".format(s))
	#print(k1,k2,k3,k4,k5)

#Negyedik feladat megoldás dictionary-vel
def negyedikOtodikFeladatv2():
	print("")
	print("4. Feladat: ")
	categories = {}
	cat = []

	for i,lines in enumerate(foglaltsag):
		for j,chair in enumerate(lines):
			if chair == "x":
				if kategoria[i][j] not in categories:
					#print(kategoria[i][j])
					categories[kategoria[i][j]] = 1
				else:
					categories[kategoria[i][j]] += 1			
	#print(categories)
	maxc = 0
	for c in categories:
		if categories[c] > maxc:
			cat = c
			maxc = categories[c]
	print("A legtöbb jegyet a {0}-es kategóriában adták el, összesen {1}-et.".format(cat,maxc))

	print("")
	print("5. Feladat: ")
	#for c in categories:
		#if c =="1"
	s = categories["1"]*5000+categories["2"]*4000+categories["3"]*3000+categories["4"]*2000+categories["5"]*1500
	print("A bevétel összege: {0} HUF.".format(s))


def hatodikFeladat():
	print("")
	print("6. Feladat: ")
	c = 0
	for i in range(len(foglaltsag)):
		if foglaltsag[i][0] == 'o' and foglaltsag[i][1] =='x':
			c+=1
		if foglaltsag[i][-2] == 'x' and foglaltsag[i][-1] =='o':
			c+=1	
		for j in range(1,len(foglaltsag)-2):
			if (foglaltsag[i][j] == 'o' and foglaltsag[i][j-1] == "x") or (foglaltsag[i][j] == 'o' and foglaltsag[i][j+1] == "x"):
				c+=1
	print("A nehezen eladható székek száma {0}.".format(c))

def hetedikFeladat():
	print("")
	print("7. Feladat: ")
	print("Kiíratás")
	rows = []
	for i,lines in enumerate(foglaltsag):
		for j,chair in enumerate(lines):
			if chair =="o":
				rows.append(kategoria[i][j])
			else:
				rows.append(chair)
		with open("szabad.txt","a") as f:
			f.write("".join(rows))
		rows = []

def main(): 
  readFile("foglaltsag.txt","kategoria.txt")
  masodikFeladat() 
  harmadikFeladat()
  #negyedikOtodikFeladat()
  negyedikOtodikFeladatv2()
  hatodikFeladat()
  hetedikFeladat()

if __name__ == '__main__':
  main()  