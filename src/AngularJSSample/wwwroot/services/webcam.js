
'use Strict'
angular
    .module('myApp')
    .factory('WebcamService', WebcamService);

WebcamService.$inject = [];

function WebcamService () {
    var webcam = {};
    webcam.isTurnOn = false;
    webcam.patData = null;
    var _video = null;
    var _stream = null;
    webcam.patOpts = {x: 0, y: 0, w: 25, h: 25};
    webcam.channel = {};
    webcam.webcamError = false;

    var getVideoData = function getVideoData(x, y, w, h) {
        var hiddenCanvas = document.createElement('canvas');
        hiddenCanvas.width = _video.width;
        hiddenCanvas.height = _video.height;
        var ctx = hiddenCanvas.getContext('2d');
        ctx.drawImage(_video, 0, 0, _video.width, _video.height);
        return ctx.getImageData(x, y, w, h);
    };

    var sendSnapshotToServer = function sendSnapshotToServer(imgBase64) {
        webcam.snapshotData = imgBase64;
    };

    webcam.makeSnapshot = function() {
        if (_video) {
            var patCanvas = document.querySelector('#snapshot');
            if (!patCanvas) return;

            patCanvas.width = _video.width;
            patCanvas.height = _video.height;
            var ctxPat = patCanvas.getContext('2d');

            var idata = getVideoData(webcam.patOpts.x, webcam.patOpts.y, webcam.patOpts.w, webcam.patOpts.h);
            ctxPat.putImageData(idata, 0, 0);

            sendSnapshotToServer(patCanvas.toDataURL());

            webcam.patData = idata;

            webcam.success(webcam.snapshotData.substr(webcam.snapshotData.indexOf('base64,') + 'base64,'.length), 'image/png');
            //webcam.turnOff();
        }
    };

    webcam.onSuccess = function () {
        _video = webcam.channel.video;
        webcam.patOpts.w = _video.width;
        webcam.patOpts.h = _video.height;
        webcam.isTurnOn = true;
    };

    webcam.onStream = function (stream) {
        activeStream = stream;
        return activeStream;
    };

    webcam.downloadSnapshot = function downloadSnapshot(dataURL) {
        window.location.href = dataURL;
    };

    webcam.onError = function (err) {
        webcam.webcamError = err;
    };

    webcam.turnOff = function () {
        webcam.isTurnOn = false;
        if (activeStream && activeStream.getVideoTracks) {
            const checker = typeof activeStream.getVideoTracks === 'function';
            if (checker) {
                return activeStream.getVideoTracks()[0].stop();
            }
            return false;
        }
        return false;
    };

    var service = {
        webcam: webcam
    };
    return service;
}
