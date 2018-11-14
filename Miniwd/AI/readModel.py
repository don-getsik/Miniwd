import pandas as pd
import numpy as np
import pickle

from sklearn.linear_model import LogisticRegression

model = pickle.load(open("saved.model", 'rb'))

pima = pd.read_csv("https://raw.githubusercontent.com/PyDataWorkshop/datasets/master/pima.csv")

test = pima.iloc[:1,:8]

print(model.predict(test)[0])

