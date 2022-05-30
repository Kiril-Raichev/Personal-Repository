function result(arr1,arr2) {
    let newArr = arr1.slice(0,arr2[0]);
    newArr.splice(0,arr2[1])

    let count =0;

    for (let num of newArr){
        if(arr2[2] == num){
            count ++;
        }
    }

    console.log(`Number ${arr2[2]} occurs ${count} times.`);
}
result([5, 2, 3, 4, 1, 6],
    [5, 2, 3]
    );