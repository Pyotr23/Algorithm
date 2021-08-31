var calPoints = function (ops: string[]) {
    let sum = 0;
    const arr: number[] = [];
    let newValue = 0;
    ops.forEach(operation => {
        switch (operation) {
            case "+":
                newValue = arr[arr.length - 1] + arr[arr.length - 2];
                break;
            case "D":
                newValue = arr[arr.length - 1] * 2;
                break;
            case "C":
                newValue = -arr[arr.length - 1];
                arr.pop();
                break;
            default:
                newValue = Number(operation);
                break;
        }
        if (operation !== "C")
            arr.push(newValue);
        sum += newValue;
    });
    return sum;
};

const res = calPoints(["5", "2", "C", "D", "+"]);