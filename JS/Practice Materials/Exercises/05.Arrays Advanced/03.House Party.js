function result(arr) {
    let list = [];
    for(i=0;i<arr.length;i++){
        let curr = arr[i].split(' ');
        if(curr[2] == "going!"){
            if(list.includes(curr[0])){
                console.log(`${curr[0]} is already in the list!`)
            }else{
                list.push(curr[0])
            }
        }
        if(curr[2] == "not"){
            if(list.includes(curr[0])){
                let index = list.indexOf(curr[0]);
                list.splice(index,1)
            }else{
                console.log(`${curr[0]} is not in the list!`)
            }
        }
    }
    for (let el of list){
        console.log(el);
    }
}
result(['Tom is going!',
'Annie is going!',
'Tom is going!',
'Garry is going!',
'Jerry is going!']

);