#-*- coding:utf-8 -*-
'''
Created on 2019. 4. 2.

@author: user
'''

from flask import Flask, request

import pymysql
#import json

app = Flask(__name__)

cur = None
connection = None

@app.route("/Signup", methods = ["POST"])

def Signup():
    msg = str()
    connection = pymysql.connect(host = 'localhost', 
                                            user = 'root', 
                                            password = 'autoset', 
                                            db = 'login_sever',
                                            charset = 'utf8mb4',
                                            cursorclass = pymysql.cursors.DictCursor)
    cur = connection.cursor()
    
    if 'id' in request.form and 'password' in request.form:
        _id=request.form['id']
        _pass = request.form['password']
        
        sql="select * from user where id='"+_id+"'"
        cur.execute(sql)
        data = cur.fetchone() # 서버로부터 하나의 데이터를 가져옴
        if data:
            msg = "fail"
        else:
            sql = "insert into user(id, pass) values('"+_id+"', '"+_pass+"')"
            cur.execute(sql)
            connection.commit()
            msg = "signup"
        cur.close()
        connection.close()
        print(msg)
        return msg
    
@app.route("/Login", methods = ["POST"])

def SignLogin():
    msg = str()
    connection = pymysql.connect(host = 'localhost', 
                                            user = 'root', 
                                            password = 'autoset', 
                                            db = 'login_sever',
                                            charset = 'utf8mb4',
                                            cursorclass = pymysql.cursors.DictCursor)
    cur = connection.cursor()
    
    if 'id' in request.form and 'password' in request.form:
        _id = request.form['id']
        _pass = request.form['password']
        
        sql="select * from user where id='"+_id+"' and pass='"+_pass+"'"
    
        cur.execute(sql)
        data = cur.fetchone()
        #json_data = json.dumps(data) # 파이썬 오브젝트(튜플, 리스트, 딕셔너리)를 문자열로 변환
        if data:
            msg = "success"
        else:
            msg = "fail"
        
    cur.close()
    connection.close()
    return msg
    
app.run(host="0.0.0.0", port=10001,debug = True)
    
    



