# exelia-challenges
Developer Challenges for Exelia


## 1. JavaScript Test

I built two versions of this test:

I was not sure if the single-page application meant only using one HTML page or if it was limited to a SPA.
- jQuery version (single-page)
- React version (SPA).

### jQuery Version

location: **1-javascript-test-jquery/**

I used [Materialize](https://materializecss.com/) as my frontend framework.

All that is needed to run the **index.html** file.

### React Version
location: **1-javascript-test-react/**

All custom environment variables can be found in the .env file

I installed Material UI for a very modern style - [https://mui.com/](https://mui.com/)

Running the application:

1. cd in to the **1-javascript-test-react/** folder.
2. run the command **npm install** to install all node modules and packages.
3. run the command **npm start**.

The JavaScript test took approximately 6 hours for both the jQuery and React version.

## 2. C# test and algorithm skills
location: **2-algorithm-test/**

A very simple class using three main methods to validate the sudoku puzzle.
Simply add the project to visual studio 2022 and run.

This test took approximately 3 and a half hours.

## 4. C# or JavaScript test for web-based back-end

location: **4-web-based-backend**

I skipped three and decided to tackle the WEB API instead.
I had a lot of difficulty with this one not going to lie. :')

It was amazing learning about dependency injection with C#

I'm sadly not very familiar with this but I would jump at the opportunity to get to learn it even more.

This test took approximately 8 hours (I had to start over in version 2022)

The web API allows for Creating Beers and Adding/Removing ratings for them.

---
### Endpoints

#### Get All Beers
**GET**
```bash
/api/Beers
```

#### Get Beer by Id
**GET**
```bash
/api/Beers/{id}
```
*Parameters:* \
id (Int - ***required***)


#### Search for a Beer by Name
**GET**
```bash
/api/Beers/search/{searchString}
```
*Parameters:* \
searchString (String - ***required***)

#### Create a new Beer
**POST**
```bash
/api/Beers
```
*Request Body:* \
name: (String - ***required***)
```json
{
  "name": "string"
}
```

#### Get Beer Rating by Beer Id
**GET**
```bash
/api/Beers/rating/{beerId}
```
*Parameters:* \
beerId (Int - ***required***)

#### Create a Rating for a Beer from 1 to 5
**POST**
```bash
/api/Beers/rating
```
*Request Body:* \
score: (Int - ***required***) - range: 1 to 5 \
beerId: (Int - ***required***)
```json
{
  "score": 1,
  "beerId": 1
}
```

#### Delete a Rating for a Beer
**DELETE**
```bash
/api/Beers/rating/{id}
```

*Parameters:* \
id (Int - ***required***)