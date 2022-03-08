function resutl(arr) {
    let array = arr;
    let arr2 = [];
    let longestLength = 1;
    let longestStart = 0;
    let currentLength = 1;
    let currentStart = 0;
    for (let i = 0; i < array.length; i++) {
        let prev = i - 1;
        if (array[i] == array[prev]) {
            currentLength++;
            if (currentLength > longestLength) {
                longestLength = currentLength;
                longestStart = currentStart;
            }
        }
        else {
            currentLength = 1;
            currentStart = i;
        }
    }
    for (let i = longestStart; i < longestStart + longestLength; i++) {
        arr2.push(arr[i]);
    }
    console.log(arr2.join(" "));

}
resutl([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);