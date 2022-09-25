# Buber Dinner API

## Contents

- [Buber Dinner API](#buber-dinner-api)
  - [Contents](#contents)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

<hr>

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Adem",
  "lastName": "Kao",
  "email": "blocmarc777@gmail.com",
  "password": "12345"
}
```
#### Register Response
```json
200 OK
```
```json
{
  "id":"21213e-213213e21-21421",  
  "firstName": "Adem",
  "lastName": "Kao",
  "email": "blocmarc777@gmail.com",
  "token": "214r3.wdfr2r"
}
```
### Login
```js
POST {{host}}/auth/login
```
#### Login Request
```json
{
  "email": "blocmarc777@gmail.com",
  "password": "12345"
}
```
#### Login Response
```json
200 OK
```
```json
{
  "id":"21213e-213213e21-21421",  
  "firstName": "Adem",
  "lastName": "Kao",
  "email": "blocmarc777@gmail.com",
  "token": "214r3.wdfr2r"
}