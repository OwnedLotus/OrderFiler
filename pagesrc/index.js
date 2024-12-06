order = Order(18021234, "hello", "TIME", ShippingMethod.CPUP, true);

console.log(order);

class Order {
    constructor(salesOrderNumber, PONumber, date, method, isPulled) {
        this.salesOrderNumber = salesOrderNumber;
        this.PONumber = PONumber;
        this.date = date;
        this.method = method;
        this.isPulled = isPulled;
    }

    getSalesOrderNumber() {
        return this.salesOrderNumber;
    }

    getPONumber() {
        return this.PONumber;
    }

    setSalesOrderNumber(soNumber) {
        this.salesOrderNumber = soNumber;
    }

    setPONumber(poNumber) {
        this.PONumber = poNumber;
    }
}

const ShippingMethod = {
    CPUP: 'CPUP',
    BACKORDER: 'BACKORDER',
    SHIPPING: 'SHIPPING',
}

class Node {
    constructor(order) {
        this.order = order;
        this.height = 1;
        this.right = null;
        this.left = null;
    }
}

class OrderAVL {
    constructor(order) {
        this.root = order;
    }

    nodeHeight(node) {
        return node ? node.height : 0;
    }

    getBalanceFactor(node) {
        return this.getHeight(node.left) - this.getHeight(node.right);
    }

    rightRotate(y) {
        const x = y.left;
        const T3 = x.right;

        // Perform rotation
        x.right = y;
        y.left = T3;

        // Update heights post rotation
        y.height = Math.max(this.getHeight(y.left), this.getHeight(y.right)) + 1;
        x.height = Math.max(this.getHeight(x.left), this.getHeight(x.right)) + 1;

        return x; // New root
    }

    leftRotate(x) {
        const y = x.right;
        const T2 = y.left;

        // Perform rotation
        y.left = x;
        x.right = T2;

        // Update heights post rotation
        x.height = Math.max(this.getHeight(x.left), this.getHeight(x.right)) + 1;
        y.height = Math.max(this.getHeight(y.left), this.getHeight(y.right)) + 1;

        return y; // New root
    }

    insert(node, data) {
        if (!node) return new Node(data);

        if (data < node.data) {
            node.left = this.insert(node.left, data);
        } else if (data > node.data) {
            node.right = this.insert(node.right, data);
        } else {
            return node; // Duplicate data not allowed.
        }

        // Update node's height.
        node.height = 1 + Math.max(this.getHeight(node.left), this.getHeight(node.right));

        // Get the balance to check if it became unbalanced.
        const balance = this.getBalanceFactor(node);

        // Left heavy scenario
        if (balance > 1) {
            if (data < node.left.data) {
                return this.rightRotate(node);
            } else {
                node.left = this.leftRotate(node.left);
                return this.rightRotate(node);
            }
        }

        // Right heavy scenario
        if (balance < -1) {
            if (data > node.right.data) {
                return this.leftRotate(node);
            } else {
                node.right = this.rightRotate(node.right);
                return this.leftRotate(node);
            }
        }

        return node;
    }

    InorderRead() {

    }
}