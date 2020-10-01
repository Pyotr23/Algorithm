var calPoints = function (ops) {
    let sum = 0;
    const stack = [];
    let newValue = 0;
    ops.forEach(operation => {
        switch (operation) {
            case "+":                
                const lastValue = stack.pop();
                const preLastValue = stack[stack.length - 1];
                newValue = lastValue + preLastValue;
                sum += newValue;
                stack.push(lastValue);
                stack.push(newValue);
                break;
            case "D":
                newValue = stack[stack.length - 1] * 2;
                stack.push(newValue);
                sum += newValue;
                break;
            case "C":
                sum -= stack.pop();
                break;
            default:
                newValue = Number(operation);
                stack.push(newValue);
                sum += newValue;
                break;
        }
    });
    return sum;
};