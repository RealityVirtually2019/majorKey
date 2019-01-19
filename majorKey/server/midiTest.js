const Express = require('express');
const ejs = require('ejs');
const path = require('path');
const BinaryClient = require('binaryjs');
const app = new Express();
var os = require("os");
var hostname = os.hostname();
app.set('PORT', process.env.PORT || 3001);
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, './views'));
app.use(Express.static('src'));
app.get('/', (request, response) => {
  response.render('index');
});
app.listen(app.get('PORT'), (error) => {
  if (error) {
    console.log('Server started with an error', error);
    process.exit(1);
  }
  console.log(`Server started and is listening at http://localhost:${app.get('PORT')}`);
})

const binaryServer = require('binaryjs').BinaryServer;
const socket = new binaryServer({
  port: 3001,
});
socket.on('connection', (client) => {
  client.on('stream', (stream, meta) => {
    stream.on('data', (data) => {
      console.log(data);
    });
    stream.on('end', () => {
      console.log('end of stream');
    });
  });
});