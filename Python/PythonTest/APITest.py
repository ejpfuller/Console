import urllib
import urllib.request
import urllib.parse
import json

url = ("https://data.police.uk/api/norfolk/neighbourhoods")
urll = urllib.request.urlopen(url)
print("\nStatus code: ", urll.getcode())

cont = urll.read()
res = json.loads(cont.decode('utf-8'))
for item in res:
    print (item['id'], item['name'])
