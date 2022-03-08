function result(arr) {
    let size = arr.shift();
    let bugs = arr.shift()
    let newArray = bugs.split(' ');

    let bugArray = [];
    for (let j = 0; j < size; j++) {
        if (newArray[j] == j) {
            bugArray.push(1);
        } else {
            bugArray.push(0);
        }
    }
    for (let i = 0; i < arr.length; i++) {
        let currentArr = arr[i].split(' ');
        let index = currentArr[0];
        let direction = currentArr[1];
        let spots = currentArr[2];

        // for (let p = 0;p<size;p++) {
        //     if (index == p && direction === 'right') {
        //         let count = 0;
        //         for (m = index + 1; m < size; m++) {
        //             if (bugArray[m] == 1) {
        //                 count++;
        //             }
        //         }
        //         bugArray[index + count + 1] = bugArray[index];
        //     }
        //     if (index == p && direction === 'left') {
        //         let count = 0;
        //         for (m = size - 1; m > index; m--) {
        //             if (bugArray[m - 1] == 1) {
        //                 count++;
        //             }
        //         }
        //         bugArray[index] = bugArray[index + count + 1];
        //     }
        //}
    }
    console.log(bugArray);
}
result([3, '0 1',
    '0 right 1',
    '2 right 1']
);

//1 1 0 - Initial field
//0 1 1 - field after "0 right 1"
//0 1 0 - field after "2 right 1"
