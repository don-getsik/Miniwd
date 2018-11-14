import pandas as pd
import numpy as np
import pickle

from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split

model = LogisticRegression()

pima = pd.read_csv("https://raw.githubusercontent.com/PyDataWorkshop/datasets/master/pima.csv")

train, test = train_test_split(pima, test_size=0.2)

train_feat = train.iloc[:,:8]
train_targ = train["Diab.1"]

test_feat = test.iloc[:,:8]
test_targ = test["Diab.1"]

model.fit(train_feat, train_targ)

pickle.dump(model, open("saved.model", 'wb'))