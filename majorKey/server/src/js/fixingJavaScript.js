(function() {
    'use strict';
    console.log('App is running');
    var midiAccess = null;
    navigator.requestMIDIAccess().then(onMidiAccessSuccess, onMidiAccessFailure);
    function onMidiAccessSuccess(access) {
      midiAccess = access;
      var inputs = midiAccess.inputs;
      var inputIterators = inputs.values();
      var firstInput = inputIterators.next().value;
      if (!firstInput) return;
      firstInput.onmidimessage = handleMidiMessage;
    }
    function onMidiAccessFailure(error) {
      console.log('Oops. Something were wrong with requestMIDIAccess', error.code);
    }
    function handleMidiMessage(e) {
      console.log(e);
    }

    var socketUrl = 'ws://' + location.hostname + ':3001';
    var client = new BinaryClient(socketUrl);
    var MIDIStream = null;
    client.on('open', function () {
      MIDIStream = client.createStream();
      MIDIStream.on('data', handleReceiveAudioData);
      MIDIStream.on('end', handleEndAudioStream);
    });
    function handleReceiveAudioData(data) {
      console.log('receive audio data', data);
    }
    function handleEndAudioStream(data) {
      console.log('end', data);
    }
    function handleMidiMessage(e) {
      console.log(e);
      if (!MIDIStream || e.data[0] !== 0x90) return;
      MIDIStream.write(e.data);
    }
  })();