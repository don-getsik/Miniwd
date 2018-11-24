import pandas as pd
import pickle
import sklearn

#Get a dictionary from execution arguments
j = int((len(sys.argv)-1)/2)
dictionary = {}
for i in range (0,j):
	dictionary[sys.argv[i*2+1]] = sys.argv[i*2+2]

#Replace City string with encoded value
le = pickle.load(open("encoder.le",'rb'))
dictionary["City"] = le.transform([dictionary["City"]])[0]

#Get a dataframe from dictionary
dataframe = pd.DataFrame(data=dictionary,index=[0])

#Read AI model

model = pickle.load(open("saved.model", 'rb'))

#Predict and print result
print(model.predict(dataframe)[0])