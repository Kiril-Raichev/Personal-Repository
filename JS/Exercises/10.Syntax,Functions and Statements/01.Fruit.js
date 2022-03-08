function result(a,b,c) {
    let fruit = a;
    let weightInKg = b/1000;
    let cost = c*weightInKg;

    console.log(`I need $${cost.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`
    )

}
result(
    'orange', 2500, 1.80
)