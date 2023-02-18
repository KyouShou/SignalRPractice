"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

$("#sendButton").hide();

connection.start().then(function () {
    $("#sendButton").show();
    console.log("連接成功");
}).catch(function (err) {
    return console.error(err.toString());
});

$("#sendButton").click(function () {
    var user = $("#userInput").val();
    var message = $("#messageInput").text();
    connection.invoke("SendMessage" , user, message).catch(function (err) {
        return console.error(err.toString());
    })
    $("#messageInput").text("");
});

connection.on("ReceiveMessage", function (user, message) {
    $("#content").append(`<p> ${user}：${message}</p><br>`);
    $("#content").animate({scrollTop:100000});
});