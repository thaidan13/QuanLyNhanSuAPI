// Thẻ tabs
$(document).ready(function () {
    // Hàm active tab nào đó
    function activeTab(obj) {
        // Xóa class active tất cả các tab
        $('.tab-wrapper ul li').removeClass('active');

        // Thêm class active vòa tab đang click
        $(obj).addClass('active');

        // Lấy href của tab để show content tương ứng
        var id = $(obj).find('a').attr('href');

        // Ẩn hết nội dung các tab đang hiển thị
        $('.tab-item').hide();

        // Hiển thị nội dung của tab hiện tại
        $(id).show();
    }

    // Sự kiện click đổi tab
    $('.tab li').click(function () {
        activeTab(this);
        return false;
    });

    // Active tab đầu tiên khi trang web được chạy
    activeTab($('.tab li:first-child'));
});

// Search

const search = () => {
    const searchBox = document.getElementById("search-item").value.toUpperCase();
    const memItem = document.getElementById("member-list");
    const member = document.querySelectorAll(".mem");
    const memName = memItem.getElementsByTagName("span");

    for (var i = 0; i < memName.length; i++) {
        let match = member[i].getElementsByTagName('span')[0];

        if (match) {
            let textValue = match.textContent || match.innerHTML

            if (textValue.toUpperCase().indexOf(searchBox) > -1) {
                member[i].style.display = "";
            } else {
                member[i].style.display = "none";
            }
        }
    }
}

// Pagination

function getPageList(totalPages, page, maxLength) {
    function range(start, end) {
        return Array.from(Array(end - start + 1), (_, i) => i + start);
    }

    var sideWidth = maxLength < 9 ? 1 : 2;
    var leftWidth = (maxLength - sideWidth * 2 - 3) >> 1;
    var rightWidth = (maxLength - sideWidth * 2 - 3) >> 1;

    if (totalPages <= maxLength) {
        return range(1, totalPages);
    }

    if (page <= maxLength - sideWidth - 1 - rightWidth) {
        return range(1, maxLength - sideWidth - 1).concat(0, range(totalPages - sideWidth + 1, totalPages));
    }

    if (page >= totalPages - sideWidth - 1 - rightWidth) {
        return range(1, sideWidth).concat(0, range(totalPages - sideWidth - 1 - rightWidth - leftWidth, totalPages));
    }

    return range(1, sideWidth).concat(0, range(page - leftWidth, page + rightWidth), 0, range(totalPages - sideWidth + 1, totalPages));
}

$(function () {
    var numberOfItems = $(".mem-container .mem").length;
    var limitPerPage = 8;
    var totalPages = Math.ceil(numberOfItems / limitPerPage);
    var paginationSize = 7;
    var currentPage;

    function showPage(whichPage) {
        if (whichPage < 1 || whichPage > totalPages) return false;
        currentPage = whichPage;

        $(".mem-container .mem").hide().slice((currentPage - 1) * limitPerPage, currentPage * limitPerPage).show();

        $("#pagination li").slice(1, -1).remove();

        getPageList(totalPages, currentPage, paginationSize).forEach(item => {
            $("<li>").addClass("page-item").addClass(item ? "current-page" : "dots")
                .toggleClass("ac", item === currentPage).append($("<a>").addClass("page-link")
                    .attr({ href: "javascript:void(0)" }).text(item || "...")).insertBefore(".next-page");
        });

        $(".previous-page").toggleClass("disable", currentPage === 1);
        $(".next-page").toggleClass("disable", currentPage === totalPages);
        return true;
    }

    $("#pagination").append(
        $("<li>").addClass("page-item").addClass("previous-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text("«")),
        $("<li>").addClass("page-item").addClass("next-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text("»"))
    );

    $(".mem-container").show();
    showPage(1);

    $(document).on("click", "#pagination li.current-page:not(.ac)", function () {
        return showPage(+$(this).text());
    });

    $(".next-page").on("click", function () {
        return showPage(currentPage + 1)
    });

    $(".previous-page").on("click", function () {
        return showPage(currentPage - 1)
    });
});
