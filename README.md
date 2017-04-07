# Mobile Applications Development 2 Project

This repository contains source code for a 3rd year undergraduate project in Mobile Applications Develeopment.
The application has been designed with the purpose of being a News Aggregation App and to provide users with a wide variety of different news sources and articles from an unbiased media outlet.

## Overview

The purpose of this project is to develop skills in building Mobile Applications Development using the Universal Windows Platform (UWP) and to demonstrate the use of Isolated Storage (Local Storage) and implementing at least one of the following features

- Accelerometer or Gyroscope
- GPS (Location Based Services)
- Sound
- Network Services (connecting to a server for data updates etc)
- Camera
- Multi Touch Gesture Management

This Universal Windows Platform application has been developed with the intensions of learning and developing an understanding for the consuming of a Restful Web Service using C# and the .NET framework. For the this UWP I chose to create a simple News Aggregation application using the Open Source API - [NewsApi.org](https://newsapi.org/). 

## News API

News API is simple web service that returns JSON metadata for headlines currently published on a range of news sources and blogs. News API currently offers content from 72 different news and blog sources across the web. Some of these include the very popular

- [BBC](http://www.bbc.com/news)
- [Sky](http://news.sky.com/)
- [Reddit](https://www.reddit.com/)
- [MTV](http://www.mtv.com/news/)
- [ABC](http://abcnews.go.com/)

News API offers two end points

- [https://newsapi.org/v1/sources](https://newsapi.org/v1/sources)

- [https://newsapi.org/v1/articles](https://newsapi.org/v1/articles)

An API Key is required to request articles from a particular source and articles can be retrieved easily by passing the News Source and API Key as Query String Paramters in the HTTP Request.

### Model

This UWP application contains a very simple and straight forward Model to follow. Classes for the NewsSources and Articles can be found under the Models directory. These are simple C# classes designed with the intension of replicating the JSON Response data returned by NewsAPI.org.

### Services

The Application operates with the help of two basic services which can be found under the Services directory. They are as follows

- NewsService - Used to obtain data JSON data from NewsAPI.org using a HTTPClient object.
- StorageService - Used to for saving article favourites to Isolated/Local Storage.

## Future Improvements

- Improve the User Interface.
- Removing of favourites from the favourites list.
- Add animations for page transitions and favouriting articles.
- Add user authentication with JSON Web Tokens.
- Replace Isolated/Local Storage with a proper database.
