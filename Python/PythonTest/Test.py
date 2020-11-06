#list = [1,2,3]

    #if list == []:
#    print ('Empty')
#else: print(list)


import time

f = time.strftime("%H:%M:%S")
r = "01:00:00"
#print (str(t))
print (f)
print (r)
ft = time.strptime(f,'%H:%M:%S')
rt = time.strptime(r,'%H:%M:%S')
print (ft.tm_hour  + rt.tm_hour)
