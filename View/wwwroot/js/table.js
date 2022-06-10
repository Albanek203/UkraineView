$(document).ready(function () {
        $(".checkAll").on("click", function () {
            if ($(".checkAll:checked").length === $(".checkAll").length) {
                $(".form-check-input").prop("checked", true);
            } else {
                $(".form-check-input").prop("checked", false);
            }
        });

        $(".sorting").click(function () {
            let lst = $(".sorting");
            for (let i = 0; i <= lst.length; i++) {
                if ($(lst[i]).hasClass("sorting_asc")) {
                    $(lst[i]).removeClass("sorting_asc");
                }
                if ($(lst[i]).hasClass("sorting_desc")) {
                    $(lst[i]).removeClass("sorting_desc");
                }
            }

            let table = $(this).parents('table').eq(0)
            let rows = table.find('tr:gt(0)').toArray().sort(comparer($(this).index()))
            this.asc = !this.asc
            if (!this.asc) {
                rows = rows.reverse();
                $(this).addClass("sorting_desc");
            } else {
                $(this).addClass("sorting_asc");
            }
            for (let i = 0; i < rows.length; i++) {
                table.append(rows[i]);
            }
        })

        function comparer(index) {
            return function (a, b) {
                let valA = getCellValue(a, index), valB = getCellValue(b, index)
                return $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : valA.toString().localeCompare(valB)
            }
        }

        function getCellValue(row, index) {
            return $(row).children('td').eq(index).text()
        }

        $(".entertainment-list-card div:last .nav-page-btn").on("click", function () {
            let button = this;
            $.ajax({
                type: "POST",
                url: "/Entertainment/JsonResponse/",
                data: {pageNumber: this.dataset.element},
                dataType: 'json',
                success: function (response) {
                    if (response != null) {
                        $(".nav-page-btn").css("background-color", "#00d6b7");
                        $(button).css("background-color", "#00ab92");
                        let temp = "";
                        for (let i = 0; i < response.length; i++) {
                            let data = response[i];
                            let activeStatus;
                            if (data["activeStatus"] === true) {
                                activeStatus = "<span className=\"active\">Active</span>"
                            } else {
                                activeStatus = "<span class=\"not-active\">Not active</span>"
                            }
                            
                            temp += `<tr>
                                        <td>
                                            <div class="form-check">
                                                <input type="checkbox" class="form-check-input">
                                            </div>
                                        </td>
                                        <td>` + data["name"] + `</td>
                                        <td>` + data["type"] + `</td>
                                        <td>` + data["rating"] + `</td>
                                        <td>` + data["region"] + `</td>
                                        <td>` + data["city"] + `</td>
                                        <td>` + data["street"] + `</td>
                                        <td class="d-flex align-items-center">` + activeStatus + `</td>
                                        <td>
                                            <div class="dropdown">
                                                <span class="dots" data-bs-toggle="dropdown" aria-expanded="false"></span>
                                                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-times mx-2 w-25"></i>Close</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-cogs mx-2 w-25"></i>Edit</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-redo-alt mx-2 w-25"></i>Refresh</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>`
                        }
                        $(".entertainment-tbody").html(temp);
                    } else {
                        console.log("Something went wrong");
                    }
                },
                error: function (response) {
                    console.log("error");
                }
            });
        });

        $(".region-list-card div:last .nav-page-btn").on("click", function () {
            let button = this;
            $.ajax({
                type: "POST",
                url: "/Region/JsonResponse/",
                data: {pageNumber: this.dataset.element},
                dataType: 'json',
                success: function (response) {
                    if (response != null) {
                        $(".nav-page-btn").css("background-color", "#00d6b7");
                        $(button).css("background-color", "#00ab92");
                        let temp = "";
                        for (let i = 0; i < response.length; i++) {
                            let data = response[i]["result"];

                            temp += `<tr>
                                        <td>
                                            <div class="form-check">
                                                <input type="checkbox" class="form-check-input">
                                            </div>
                                        </td>
                                        <td>` + data["name"] + `</td>
                                        <td>` + data["identifier"] + `</td>
                                        <td>` + data["area"] + `</td>
                                        <td>` + data["formed"] + `</td>
                                        <td>` + data["entertainmentCount"] + `</td>
                                        <td>` + data["monumentCount"] + `</td>
                                        <td>
                                            <div class="dropdown">
                                                <span class="dots" data-bs-toggle="dropdown" aria-expanded="false"></span>
                                                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-times mx-2 w-25"></i>Close</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-cogs mx-2 w-25"></i>Edit</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-redo-alt mx-2 w-25"></i>Refresh</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>`
                        }
                        $(".region-tbody").html(temp);
                    } else {
                        console.log("Something went wrong");
                    }
                },
                error: function (response) {
                    console.log("error");
                }
            });
        });

        $(".monument-list-card div:last .nav-page-btn").on("click", function () {
            let button = this;
            $.ajax({
                type: "POST",
                url: "/Monument/JsonResponse/",
                data: {pageNumber: this.dataset.element},
                dataType: 'json',
                success: function (response) {
                    if (response != null) {
                        $(".nav-page-btn").css("background-color", "#00d6b7");
                        $(button).css("background-color", "#00ab92");
                        let temp = "";
                        for (let i = 0; i < response.length; i++) {
                            let data = response[i]["result"];

                            temp += `<tr>
                                        <td>
                                            <div class="form-check">
                                                <input type="checkbox" class="form-check-input">
                                            </div>
                                        </td>
                                        <td>` + data["name"] + `</td>
                                        <td>` + data["region"] + `</td>
                                        <td>` + data["city"] + `</td>
                                        <td>` + data["street"] + `</td>
                                        <td>` + data["rating"] + `</td>
                                        <td>
                                            <div class="dropdown">
                                                <span class="dots" data-bs-toggle="dropdown" aria-expanded="false"></span>
                                                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-times mx-2 w-25"></i>Close</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-cogs mx-2 w-25"></i>Edit</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-redo-alt mx-2 w-25"></i>Refresh</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>`
                        }
                        $(".monument-tbody").html(temp);
                    } else {
                        console.log("Something went wrong");
                    }
                },
                error: function (response) {
                    console.log("error");
                }
            });
        });

        $(".user-list-card div:last .nav-page-btn").on("click", function () {
            let button = this;
            $.ajax({
                type: "POST",
                url: "/User/JsonResponse/",
                data: {pageNumber: this.dataset.element},
                dataType: 'json',
                success: function (response) {
                    if (response != null) {
                        $(".nav-page-btn").css("background-color", "#00d6b7");
                        $(button).css("background-color", "#00ab92");
                        let temp = "";
                        for (let i = 0; i < response.length; i++) {
                            let data = response[i]["result"];

                            let img;
                            if (data["photoPath"] === "null") {
                                img = "<i class=\"fa fa-question-circle avatar\" aria-hidden=\"true\"></i>";
                            } else {
                                img = "<img src=\"" + data["photoPath"] + "\" alt=\"User photo\" class=\"avatar\">";
                            }
                            let role = data["role"] === null ? "User" : data["role"];

                            temp += `<tr>
                                        <td>
                                            <div class="form-check">
                                                <input type="checkbox" class="form-check-input">
                                            </div>
                                        </td>
                                        <td class="text-center">` + img + `</td>
                                        <td>` + data["nickname"] + `</td>
                                        <td>` + role + `</td>
                                        <td>` + data["gender"] + `</td>
                                        <td>` + data["birthDay"] + `</td>
                                        <td>` + data["phone"] + `</td>
                                        <td>` + data["email"] + `</td>
                                        <td>
                                            <div class="dropdown">
                                                <span class="dots" data-bs-toggle="dropdown" aria-expanded="false"></span>
                                                <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-times mx-2 w-25"></i>Close</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-cogs mx-2 w-25"></i>Edit</a>
                                                    </li>
                                                    <li>
                                                        <a class="dropdown-item" href="#"><i class="fas fa-redo-alt mx-2 w-25"></i>Refresh</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>`
                        }
                        $(".user-tbody").html(temp);
                    } else {
                        console.log("Something went wrong");
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
        });
    }
);