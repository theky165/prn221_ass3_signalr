"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalRServer")
    .build();

connection.on("LoadCourses", function () {
    location.href='/Courses'
});

connection.on("LoadPosts", function () {
    location.href='/Posts'
});

connection.on("LoadMembers", function () {
    location.href='/Members'
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});