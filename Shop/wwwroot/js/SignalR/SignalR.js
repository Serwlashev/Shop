const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000//cartHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

$("button").click(() => {
    let message = $("#txtMessage").val();
    connection.invoke("SendMessageAsync", message)
        .catch(error => console.log("Mesaj gönderilirken hata alınmıştır."));
});

connection.on("receiveMessage", message => {
    $("#messages").append(`${message}<br>`);
});

connection.onclose(async () => {
    await start();
});

// Start the connection.
start();