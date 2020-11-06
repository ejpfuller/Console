shopping = ["Apple","Banana","Orange","Grape","Kiwi","Bread","Soup","Carrot","Cheese","Milk"]

item = "Apple"
i = 0
var = False
while i < len(shopping) and var == False:
    if shopping[i] != item:
        i+=1
    elif shopping[i] == item:
        print "Yes"
        var = True

if var == False:
    print "Not Found"
