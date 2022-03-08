function result(a,b,c) {
    let steps = a;
    let footprintLengthInMeters = b;
    let speed = c;

    let distanceInMeters = steps*footprintLengthInMeters;
    let numberOfBreaks = Math.floor(distanceInMeters/500);
    let speedInMperS = speed*1000/3600;
    let timeInSeconds = (distanceInMeters/speedInMperS) + (numberOfBreaks*60);
    
    let hours = Math.floor(timeInSeconds / 3600);
    if (hours < 10){
        hours = "0" + hours;
    }
    let minutes = Math.floor(timeInSeconds / 60);
    if (minutes < 10){
        minutes = "0" + minutes;
    }
    let seconds = Math.ceil(timeInSeconds % 60);
    if (seconds < 10){
        seconds = "0" + seconds;
    }
    console.log(`${hours}:${minutes}:${seconds}`)
}
result(
    4000, 0.60, 5
    )