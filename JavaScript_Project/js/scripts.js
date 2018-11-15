/*
 Project 1 - Happy Grillmore
 Erica Kim
 June 18, 2018
 */

var nowHours = new Date();
nowHours = nowHours.getHours();

//home page output handle
function mainOutput() {

    var heading = document.getElementById('heading');
    var pic1 = document.getElementById('foodpic1');
    var pic2 = document.getElementById('foodpic2');
    var pic3 = document.getElementById('foodpic3');

    if (nowHours >= 7 && nowHours < 12) {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#ffff66';
        heading.innerHTML = 'We are currently open for Breakfast from 7am to 12pm';
        pic1.src = 'img/breakfast1.jpg';
        pic2.src = 'img/breakfast2.jpg';
        pic3.src = 'img/breakfast3.jpg';
    }
    else if (nowHours >= 12 && nowHours < 16) {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#ff9933';
        heading.innerHTML = 'We are currently open for Lunch from 12pm to 4pm';
        pic1.src = 'img/lunch1.jpg';
        pic2.src = 'img/lunch2.jpg';
        pic3.src = 'img/lunch3.jpg';
    }
    else if (nowHours >= 16 && nowHours < 22) {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#cc3300';
        heading.innerHTML = 'We are currently open for Dinner from 4pm to 10pm';
        pic1.src = 'img/dinner1.jpg';
        pic2.src = 'img/dinner2.jpg';
        pic3.src = 'img/dinner3.jpg';
    }
    else {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#e0e0d1';
        heading.innerHTML = 'We are currently closed. We are open daily from 7am to 10pm';
        pic1.src = 'img/dinner2.jpg';
        pic2.src = 'img/lunch2.jpg';
        pic3.src = 'img/breakfast2.jpg';
    }
}

function mouseOverProvider(picture) {

    if (nowHours >= 7 && nowHours < 22) {
        picture.src = 'img/linkMenu.jpg';
    }
    else {
        picture.src = 'img/closed.jpg';
    }
}

function mouseOutProvider(picture) {

    var pic1 = document.getElementById('foodpic1');
    var pic2 = document.getElementById('foodpic2');
    var pic3 = document.getElementById('foodpic3');

    if (nowHours >= 7 && nowHours < 12) {
        if (pic1 === picture) {
            picture.src = 'img/breakfast1.jpg';
        }
        else if (pic2 === picture) {
            picture.src = 'img/breakfast2.jpg';
        }
        else {
            picture.src = 'img/breakfast3.jpg';
        }
    }
    else if (nowHours >= 12 && nowHours < 16) {
        if (pic1 === picture) {
            picture.src = 'img/lunch1.jpg';
        }
        else if (pic2 === picture) {
            picture.src = 'img/lunch2.jpg';
        }
        else {
            picture.src = 'img/lunch3.jpg';
        }
    }
    else if (nowHours >= 16 && nowHours < 22) {
        if (pic1 === picture) {
            picture.src = 'img/dinner1.jpg';
        }
        else if (pic2 === picture) {
            picture.src = 'img/dinner2.jpg';
        }
        else {
            picture.src = 'img/dinner3.jpg';
        }
    }
    else {
        if (pic1 === picture) {
            picture.src = 'img/dinner2.jpg';
        }
        else if (pic2 === picture) {
            picture.src = 'img/lunch2.jpg';
        }
        else {
            picture.src = 'img/breakfast2.jpg';
        }
    }
}

function linkMenu() {
    if (nowHours >= 7 && nowHours < 22) {
        window.location.href = 'menu.html';
    }
    else {
        window.location.href = 'index.html';
    }
}


//menu page : functions and variables
function menuOutput() {
    var heading = document.getElementById('heading');

    if (nowHours >= 7 && nowHours < 12) {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#ffff66';
        heading.innerHTML = 'Breakfast Menu';
        drawFoodBoard('appitizer', bf_appetizers);
        drawFoodBoard('entree', bf_entrees);
        drawFoodBoard('dessert', bf_desserts);
        drawFoodBoard('beverage', bf_beverages);
    }
    else if (nowHours >= 12 && nowHours < 16) {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#ff9933';
        heading.innerHTML = 'Lunch Menu';
        drawFoodBoard('appitizer', lunch_appetizers);
        drawFoodBoard('entree', lunch_entrees);
        drawFoodBoard('dessert', lunch_desserts);
        drawFoodBoard('beverage', lunch_beverages);
    }
    else if (nowHours >= 16 && nowHours < 22) {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#cc3300';
        heading.innerHTML = 'Dinner Menu';
        drawFoodBoard('appitizer', dinner_appetizers);
        drawFoodBoard('entree', dinner_entrees);
        drawFoodBoard('dessert', dinner_desserts);
        drawFoodBoard('beverage', dinner_beverages);
    }
    else {
        document.getElementsByTagName('body')[0].style.backgroundColor = '#e0e0d1';
        heading.innerHTML = 'Dinner Menu';
        drawFoodBoard('appitizer', dinner_appetizers);
        drawFoodBoard('entree', dinner_entrees);
        drawFoodBoard('dessert', dinner_desserts);
        drawFoodBoard('beverage', dinner_beverages);
    }
}

//food constructor
function Food(f_id, f_name, f_price) {
    var id = f_id;
    var name = f_name;
    var price = f_price;

    this.getId = function () { return id; }
    this.getName = function () { return name; }   
    this.getPrice = function () { return price; }

    this.getPriceString = function () {
        return getCurrencyString(price);
    }
    this.getSummary = function () {
        return id + '. ' + name + ' ' + this.getPriceString();
    }
}

function createNoSelection() {
    return new Food(1, '** No selection **', 0);
}

//currency set up e.g.) $0.00
function getCurrencyString(price) {
    return price.toLocaleString('en-CA', { style: 'currency', currency: 'CAD' });
}

//function for drawing menu divs
function drawFoodBoard(foodSection, foods) {
    var board = document.getElementById(foodSection + '_board');  

    for (var i = 0; i < foods.length; i++) {
        var food = foods[i];
        if (i > 0) {
            board.append(document.createElement('br'));
        }
        board.append(document.createTextNode(food.getSummary()));
    }
}

//Check the value of each item number entered. If the number is wrong show the alert.
//Add "" if the selection is "1" not to include "no selection" in the summary
//Calculate total bill  
//Display the order summary and total bill
function subTotalOrder() {
    var app_select = document.getElementById('appitizer_selector').value;
    var ent_select = document.getElementById('entree_selector').value;
    var des_select = document.getElementById('dessert_selector').value;
    var bev_select = document.getElementById('beverage_selector').value;

    var order_app;
    var order_app_price;

    if (app_select === '1') {
        order_app = '';
        order_app_price = 0.0;
    }
    else if (app_select === '2' || app_select === '3' || app_select === '4') {
        if (nowHours >= 7 && nowHours < 12) {
            var order = bf_appetizers[app_select - 1];
            order_app = order.getSummary();
            order_app_price = order.getPrice();
        }
        else if (nowHours >= 12 && nowHours < 16) {
            var order = lunch_appetizers[app_select - 1];
            order_app = order.getSummary();
            order_app_price = order.getPrice();
        }
        else {
            var order = dinner_appetizers[app_select - 1];
            order_app = order.getSummary();
            order_app_price = order.getPrice();
        }
    }
    else {
        alert('Enter the valid number of Appetizer');
        return;
    }

    var order_ent;
    var order_ent_price;

    if (ent_select === '1') {
        order_ent = '';
        order_ent_price = 0.0;
    }
    else if (ent_select === '2' || ent_select === '3' || ent_select === '4') {
        if (nowHours >= 7 && nowHours < 12) {
            var order = bf_entrees[ent_select - 1];
            order_ent = order.getSummary();
            order_ent_price = order.getPrice();
        }
        else if (nowHours >= 12 && nowHours < 16) {
            var order = lunch_entrees[ent_select - 1];
            order_ent = order.getSummary();
            order_ent_price = order.getPrice();
        }
        else {
            var order = dinner_entrees[ent_select - 1];
            order_ent = order.getSummary();
            order_ent_price = order.getPrice();
        }
    }
    else {
        alert('Enter the valid number of Entree');
        return;
    }

    var order_des;
    var order_des_price;

    if (des_select === '1') {
        order_des = '';
        order_des_price = 0.0;
    }
    else if (des_select === '2' || des_select === '3' || des_select === '4') {
        if (nowHours >= 7 && nowHours < 12) {
            var order = bf_desserts[des_select - 1];
            order_des = order.getSummary();
            order_des_price = order.getPrice();
        }
        else if (nowHours >= 12 && nowHours < 16) {
            var order = lunch_desserts[des_select - 1];
            order_des = order.getSummary();
            order_des_price = order.getPrice();
        }
        else {
            var order = dinner_desserts[des_select - 1];
            order_des = order.getSummary();
            order_des_price = order.getPrice();
        }
    }
    else {
        alert('Enter the valid number of Dessert');
        return;
    }

    var order_bev;
    var order_bev_price;

    if (bev_select === '1') {
        order_bev = '';
        order_bev_price = 0.0;
    }
    else if (bev_select === '2' || bev_select === '3' || bev_select === '4') {
        if (nowHours >= 7 && nowHours < 12) {
            var order = bf_beverages[bev_select - 1];
            order_bev = order.getSummary();
            order_bev_price = order.getPrice();
        }
        else if (nowHours >= 12 && nowHours < 16) {
            var order = lunch_beverages[bev_select - 1];
            order_bev = order.getSummary();
            order_bev_price = order.getPrice();
        }
        else {
            var order = dinner_beverages[bev_select - 1];
            order_bev = order.getSummary();
            order_bev_price = order.getPrice();
        }
    }
    else {
        alert('Enter the valid number of Beverage');
        return;
    }

    var outOrder = 'Appetizer: ' + order_app + '<br>' + 'Entree: ' + order_ent + '<br>' + 'Dessert: ' + order_des + '<br>' + 'Beverage: ' +order_bev + '<br>';
    var total_bill = order_app_price + order_ent_price + order_des_price + order_bev_price;
    document.getElementById('output').innerHTML = outOrder + 'Total: $' + total_bill.toFixed(2);
}

//clear textbox and div output
function clearOrder() {
    document.getElementById('output').innerHTML = '';
    document.getElementById('appitizer_selector').value = 1;
    document.getElementById('entree_selector').value = 1;
    document.getElementById('dessert_selector').value = 1;
    document.getElementById('beverage_selector').value = 1;
}

// breakfast menu data
var bf_appetizers = [createNoSelection(), new Food(2, 'Toast', 1.99), new Food(3, 'English Muffin', 1.99), new Food(4, 'Hash Browns', 3.39)];

var bf_entrees = [createNoSelection(), new Food(2, 'Oatmeal', 4.29), new Food(3, 'Belgian Waffles', 6.99), new Food(4, 'Pancakes', 5.59)];

var bf_desserts = [createNoSelection(), new Food(2, 'Fresh Fruit Cup', 3.99), new Food(3, 'Danish Pastry', 1.99), new Food(4, 'Coffee Cake', 3.59)];

var bf_beverages = [createNoSelection(), new Food(2, 'Water', 0), new Food(3, 'Hot Chocolate', 2.59), new Food(4, 'Coffee', 2.25)];

//lunch menu data
var lunch_appetizers = [createNoSelection(), new Food(2, 'Caesar Salad', 5.49), new Food(3, 'Garlic Bread', 4.99), new Food(4, 'Tossed Salad', 4.89)];

var lunch_entrees = [createNoSelection(), new Food(2, 'Western Sandwich', 8.99), new Food(3, 'Club House Sandwich', 9.99), new Food(4, 'Buffalo Chicken Sandwich', 11.99)];

var lunch_desserts = [createNoSelection(), new Food(2, 'Ice Cream Sundae', 2.95), new Food(3, 'Cheesecake', 5.99), new Food(4, 'Chocolate Truffle Case', 6.99)];

var lunch_beverages = [createNoSelection(), new Food(2, 'Water', 0), new Food(3, 'Juice', 2.5), new Food(4, 'Pop', 2)];

//Dinner menu data
var dinner_appetizers = [createNoSelection(), new Food(2, 'Deep Fried Calamari', 7.99), new Food(3, 'Soup of the day', 5.99), new Food(4, 'Tossed Salad', 4.89)];

var dinner_entrees = [createNoSelection(), new Food(2, 'Rib-Steak', 15.95), new Food(3, 'Fettuccini Alfredo', 11.25), new Food(4, 'Pan-fried Sole', 17.95)];

var dinner_desserts = [createNoSelection(), new Food(2, 'Ice Cream Sundae', 2.95), new Food(3, 'Cheesecake', 5.99), new Food(4, 'Chocolate Truffle Case', 6.99)];

var dinner_beverages = [createNoSelection(), new Food(2, 'Water', 0), new Food(3, 'Juice', 2.5), new Food(4, 'Pop', 2)];

