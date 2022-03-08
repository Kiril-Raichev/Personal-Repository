function result(array) {
    let list = {
        vip:[],
        regular:[]
    };
    let guest = array.shift();// proverka dali 1viq element e party
    while(guest !== "PARTY"){
        let firstChar = guest[0];
        if(isNaN(firstChar)){ // proverka dali 1viq element e chislo
            list.regular.push(guest);
        }else{
            list.vip.push(guest);
        }
        guest = array.shift();
    }
    for(let guest of array){
        if(list.vip.includes(guest)){
            let index = list.vip.indexOf(guest);
            list.vip.splice(index,1);
        }else if(list.regular.includes(guest)){
            let index = list.regular.indexOf(guest);
            list.regular.splice(index,1);
        }
    }
    let vipCount = list.vip.length;
    let regularCount = list.regular.length;
    console.log(vipCount+regularCount);
    console.log(list.vip.join("\n"));
    console.log(list.regular.join("\n"));

}
result(
['7IK9Yo0h',
'9NoBUajQ',
'Ce8vwPmE',
'SVQXQCbc',
'tSzE5t0p',
'PARTY',
'9NoBUajQ',
'Ce8vwPmE',
'SVQXQCbc'
]
);