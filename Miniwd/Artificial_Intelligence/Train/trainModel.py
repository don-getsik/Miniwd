import pandas as pd
import pickle

from sklearn.ensemble import RandomForestClassifier
from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder

model = RandomForestClassifier()

data = pd.read_csv("data.csv", engine='python')

data = data.replace('K',1)
data = data.replace('W',0)
data = data.replace('M',1)
data = data.replace('P',0)

le = LabelEncoder()
le.fit(data.iloc[:,8:9])

data.iloc[:,8:9] = le.transform(data.iloc[:,8:9])

train, test = train_test_split(data, test_size=0.2)

train_feat = train.iloc[:,:13]
train_targ = train["IsGoodOfert"]

model.fit(train_feat, train_targ)

pickle.dump(model, open("saved.model", 'wb'))
pickle.dump(le,open("encoder.le",'wb'))