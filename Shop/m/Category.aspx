﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.P_ProductCategory" validateRequest="false"%>


<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% LoadPage("ljq@lebi.cn_43",15,"CN","P_ProductCategory"); %>

<!DOCTYPE html PUBliC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=ThemePageMeta("P_ProductCategory","title")%></title>
<meta name="keywords" content="<%=ThemePageMeta("P_ProductCategory","keywords")%>" />
<meta name="description" content="<%=ThemePageMeta("P_ProductCategory","description")%>" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Content-Language" content="utf-8" />
<meta name="format-detection" content="telephone=no" />
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" />
<meta name="apple-mobile-web-app-status-bar-style" content="black" />
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="twcClient" content="false" id="twcClient" />
<meta name="revisit-after" content="1 days" />
<meta name="CurrenctCurrency" content="<%=CurrentCurrency.Code %>" />
<meta name="CurrenctCurrencyMsige" content="<%=CurrentCurrency.Msige %>" />
<meta name="CurrentExchangeRate" content="<%=CurrentCurrency.ExchangeRate %>" />
<meta name="CurrenctCurrencyLength" content="<%=CurrentCurrency.DecimalLength %>" />
<meta name="CurrentLanguage" content="<%=CurrentLanguage.Code %>" />
<meta name="generator" content="LebiShop V<%=SYS.Version+"."+SYS.Version_Son %>" />
<meta name="copyright" content="2003-<%=DateTime.Now.Year %> lebi.cn" />
<script src="/Theme/system/wap/js/jquery-3.1.0.min.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/jquery-ias.min.js"></script>
<%if (CurrentLanguage.IsLazyLoad==1){ %><script src="/Theme/system/wap/js/jquery.lazyload.min.js" type="text/javascript"></script><%} %>
<script src="/Theme/system/wap/js/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
<%if (CurrentLanguage.Code=="CN"){%><script type="text/javascript" src="/Theme/system/wap/js/jquery-ui/datepicker-zh-CN.js"></script><%}%>
<script src="<%=WebPath %>/ajax/js.aspx" type="text/javascript"></script>
<script src="/Theme/system/wap/js/main.js" type="text/javascript"></script>
<script src="/Theme/system/wap/js/messagebox.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/css/system.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.min.css" />
<link rel="stylesheet" type="text/css" href="/Theme/system/wap/js/jquery-ui/jquery-ui.theme.min.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/css.css" />
<link rel="stylesheet" type="text/css" href="/theme/wap/css/<%=CurrentLanguage.Code %>.css" />

    
</head>
<body class="default">
    
<div class="mhead clearfix">
	<a href="javascript:history.go(-1);" class="a-back"><span>返回</span></a>
	<h2 id="pagename"><%=ThemePageMeta("P_ProductCategory","title")%></h2>
	<a href="<%=URL("P_AllProductCategories","")%>" class="a-cate"><span>商品分类</span></a>
</div>
<script>
    var pagetitle = $("#pagename").html();
    if (pagetitle.indexOf(" - ") > -1) {
        $("#pagename").html(pagetitle.split(' - ')[0]);
    }
</script>

    <div class="body">
        <div class="bodymain">
            
<div class="search">
	<a name="search"></a>
	

<script type="text/javascript">
    $(function () {
        blurInput('#keyword', '<%if (Rstring("Keyword")!=""){ %><%=Rstring("Keyword")%><%}else{%><%Table="Lebi_Searchkey";Where="Type=1";Order="Sort desc,id desc";PageSize=1;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int xpFc_index=1;
List<Lebi_Searchkey> xpFcs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey xpFc in xpFcs){%><%=Lang(xpFc.Name)%><%xpFc_index++;}%><%} %>');
        $(".searchform .button").click(function(){
            var typename = $('#searchtype').attr('typename');
            var url = "";
            if (typename=="product")
            {
                var url = "<%=URL("P_Search","[key]") %>";
            }
            if (typename=="shop")
            {
                url = "<%=URL("P_ShopSearch","[key]") %>";
            }
            location.href = url.replace("[key]",escape($("#keyword").val()));
            return false;
        });
        $(".searchform dd a").click(function(){
            $(".searchform dl span").text($(this).text());
            $(".searchform dl span").attr("typename",$(this).attr("typename"));
            $(".searchform dd").hide();
        });
        $(".searchform-type dt").click(function () {
            $(".searchform dd").show();
        });
        $(".searchform dd a").click(function () {
            $(".searchform dl span").text($(this).text());
            $(".searchform dl span").attr("typename", $(this).attr("typename"));
            $(".searchform dd").hide();
            $("#keyword").val("");
        });
        <%if(!IsAPP()){%>
        $(".searchform-ipt input").click(function(){
            $("#keywords").show();
        });
        $("#keywords .mbox").hover(function(){
            $("#keywords").show();
        }, function () {
            $("#keywords").hide();
        });
        <%}%>
    });		
</script>
<div id="searchform">
<div class="searchform">
<div class="searchform-type">
<dl>
    <dt><span id="searchtype" typename="product">商品</span><em class="ico-jtb"></em></dt>
    <dd>
        <a typename="product" href="javascript:void(0)">商品</a>
        <%if (Shop.LebiAPI.Service.Instanse.Check("plugin_gongyingshang")){ %>
        <a typename="shop" href="javascript:void(0)">店铺</a>
        <%}%>
    </dd>
</dl>
</div>
<div class="searchform-ipt">
<input id="keyword" value="" type="text" name="keyword" onkeydown="if(event.keyCode==13){search();}" />
</div>
<div class="searchform-btn">
<input type="button" value="搜索" class="button" />
</div>
</div>
<%if(!IsAPP()){%>
<div id="keywords">
    <div class="mbox clearfix">
    <div class="searchkeyword">
    <div class="mt">
        <h2>热搜排行</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Searchkey";Where="";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Searchkey.Counts(Where);int tKTK_index=1;
List<Lebi_Searchkey> tKTKs = B_Lebi_Searchkey.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Searchkey tKTK in tKTKs){%>
        <li><%if (tKTK.Type==1){ %><a href="<%=URL("P_Search",""+Lang(tKTK.Name)+"") %>"><%}else{ %><a href="<%=tKTK.URL%>"><%} %><%=Lang(tKTK.Name)%></a></li>
        <%tKTK_index++;}%>
    </ul>
    </div>
    </div>
    <div class="searchbrand">
    <div class="mt">
        <h2>品牌推荐</h2>
    </div>
    <div class="mc clearfix">
    <ul class="text">
        <%Table="Lebi_Brand";Where="IsRecommend=1";Order="Sort desc,id desc";PageSize=18;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int WRXj_index=1;
List<Lebi_Brand> WRXjs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand WRXj in WRXjs){%>
        <li><a href="<%=URL("P_Brand",WRXj.id)%>" title="<%=Lang(WRXj.Name) %>"><%=Lang(WRXj.Name) %></a></li>
        <%WRXj_index++;}%>
    </ul>
    </div>
    </div>
    </div>
</div>
</div>
<%}%>

</div>


<div class="mbox clearfix">
<div class="cateporys">
<div class="mt">
    <h2>商品分类</h2>
</div>
<div class="mc clearfix">
<ul class="big">
    <%List<Shop.Model.Lebi_Pro_Type> BuzCs=Cateporys(id);RecordCount=BuzCs.Count;int BuzC_index=1;
foreach (Shop.Model.Lebi_Pro_Type BuzC in BuzCs){%>
    <%if (BuzC.IsIndexShow == 1){ %>
    <li><a href="<%=URL("P_ProductCategory",BuzC.id,Lang(BuzC.Url)) %>" title="<%=Lang(BuzC.Name) %>"><%=Lang(BuzC.Name) %></a> <em>(<%=Shop.Bussiness.EX_Product.OnSaleTypeProductCount(BuzC.id)%>)</em>
    </li>
    <%} %>
    <%BuzC_index++;}%>
</ul>
</div>
</div>
</div>

<%if (id > 0){ %>


<div class="nbbox clearfix">
    <div class="searchselect">
        <div class="mt">
            <h2>
                商品筛选</h2>
        </div>
        <div class="mc clearfix">
            <ul class="selectvalue">
                <li><%Table="Lebi_Brand";Where="','+Pro_Type_id+',' like '%,"+pro_type.id+",%'";Order="Sort desc";PageSize=999;pageindex=1;RecordCount=B_Lebi_Brand.Counts(Where);int iowj_index=1;
List<Lebi_Brand> iowjs = B_Lebi_Brand.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_Brand iowj in iowjs){%>
                    <% 
            if(iowj_index==1 && RecordCount>0){
                    %>
                    <span>商品品牌：</span> <a href="<%=URL("P_ProductCategory",""+id+",0,"+cid+",$,$,"+tid+"") %>"
                        <%=pid==0?"class=\"selectall\"":"" %>>全部</a>
                    <%} %>
                    <a href="<%=URL("P_ProductCategory",""+id+","+iowj.id+","+cid+",$,$,"+tid+"") %>" <%=pid==iowj.id?"class=\"selectone\"":"" %>>
                        <%=Lang(iowj.Name) %></a> <%iowj_index++;}%> </li>
                <%Table="Lebi_ProPerty";Where="parentid=0 and id in ("+property.ProPerty132+")";Order="Sort desc";PageSize=999;pageindex=1;RecordCount=B_Lebi_ProPerty.Counts(Where);int pty_index=1;
List<Lebi_ProPerty> ptys = B_Lebi_ProPerty.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ProPerty pty in ptys){%>
                <li><span>
                    <%=Lang(pty.Name) %>：</span> <a href="<%=URL("P_ProductCategory",""+id+","+pid+","+Categoryhref(pty.id,0,cid)+",$,$,"+tid+"") %>"
                        <%=(cid.Contains(pty.id+"|0") || !cid.Contains(pty.id+"|"))?"class=\"selectall\"":"" %>>
                        全部</a> 
                        <%Table="Lebi_ProPerty";Where="parentid="+pty.id+"";Order="Sort desc";PageSize=999;pageindex=1;RecordCount=B_Lebi_ProPerty.Counts(Where);int m_index=1;
List<Lebi_ProPerty> ms = B_Lebi_ProPerty.GetList(Where, Order,PageSize ,pageindex);foreach (Lebi_ProPerty m in ms){%> 
                        <a href="<%=URL("P_ProductCategory",""+id+","+pid+","+Categoryhref(pty.id,m.id,cid)+",$,$,"+tid+"") %>"
                        <%=cid.Contains(pty.id+"|"+m.id)?"class=\"selectone\"":"" %>>
                        <%=Lang(m.Name) %></a>
                        <%m_index++;}%> 
               <%pty_index++;}%>
        </div>
    </div>
</div>


<%} %>


<%if (CurrentLanguage.IsLazyLoad==1){ %>
<script type="text/javascript">
    $(document).ready(
    function ($) {
        $("img.listlazy").lazyload({
            threshold: 300,
            effect: "fadeIn"
        });
    });
</script>
<%} %>
<div class="nbbox clearfix">
<div id="filter">
	<div class="fore1">
		<dl class="order">
			<dt>排序：</dt>
			<dd <%if(sort == "1" || sort == "1a"){ %>class="curr <%if(sort == "1"){ %>up<%}else if(sort == "1a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ProductCategory",""+id+","+pid+","+cid+","+list+",1"+ordertmp+","+tid+"") %>">销量</a><b></b></dd>
			<dd <%if(sort == "2" || sort == "2a"){ %>class="curr <%if(sort == "2"){ %>up<%}else if(sort == "2a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ProductCategory",id+","+pid+","+cid+","+list+",2"+ordertmp+","+tid+"") %>">价格</a><b></b></dd>
			<dd <%if(sort == "3" || sort == "3a"){ %>class="curr <%if(sort == "3"){ %>up<%}else if(sort == "3a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ProductCategory",id+","+pid+","+cid+","+list+",3"+ordertmp+","+tid+"") %>">评价数</a><b></b></dd>
			<dd <%if(sort == "4" || sort == "4a"){ %>class="curr <%if(sort == "4"){ %>up<%}else if(sort == "4a"){ %>down<%} %>"<%} %>><a href="<%=URL("P_ProductCategory",id+","+pid+","+cid+","+list+",4"+ordertmp+","+tid+"") %>">上架时间</a><b></b></dd>
		</dl>
        <div class="list-cutover">
			<a id="list-unselected"  href="<%=URL("P_ProductCategory",""+id+","+pid+","+cid+",2,"+ sort +","+tid+"") %>" class="modfiy-url list-unselected <%=list=="2"?"list-curr":"" %>"><b></b>列表</a>
			<a id="grid-unselected"  href="<%=URL("P_ProductCategory",""+id+","+pid+","+cid+",1,"+ sort +","+tid+"") %>" class="modfiy-url grid-unselected <%=(list=="1" || list=="")?"grid-curr":"" %>"><b></b>网格</a>
		</div>
		<div class="pagin pagin-m" id="top_pagi">
			<%=HeadPage%>
		</div>
		<div class="total">
			<span>共<strong> <%=B_Lebi_Product.Counts(where) %> </strong>个商品</span>
		</div>
		<span class="clr"></span>
	</div>
</div>
<div class="mc clearfix">
    <div class="productlist loadlist"><ul>
        <%foreach (Shop.Model.Lebi_Product pro in products)
        {
        if (list == "" || list == "1"){ %>
        <li class="grid loadli">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/wap/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
            <%if (pro.Price_Market > 0){ %><div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(ProductPrice_Market(pro)) %></strong></div><%} %>
            <%if (pro.Type_id_ProductType == 321){ %>
            <div class="buyprice"><i>抢购价：</i><strong><%=FormatMoney(pro.Price_Sale) %></strong><em><%=Discount(pro.Price_Market,pro.Price_Sale) %>% 折</em></div>
			<%}else{%>
			<div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div>
            <%} %>
            <div class="probtn">
                <%if(ProductStock(pro)<1 && SYS.IsNullStockSale!="1" && pro.Type_id_ProductType!=324){ %>
                <strong>已售罄</strong>
                <%}else{ %>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,142,1);" class="buy btn btn-12"><s></s>加入购物车</a>
                <%} %>
            </div>
            </div>
        </li>
        <%}else{ %>
        <li class="list loadli">
            <div class="proimg">
                <p><a href="<%=URL("P_Product",pro.id) %>"><img <%if (CurrentLanguage.IsLazyLoad==1){ %>class="listlazy" src="/Theme/system/wap/images/lazy.gif" data-original<%}else{ %>src<%} %>="<%=Image(pro,"medium")%>" alt="<%=Lang(pro.Name) %>" title="<%=Lang(pro.Name) %>" /></a></p></div>
            <div class="proname">
                <a href="<%=URL("P_Product",pro.id) %>" title="<%=Lang(pro.Name) %>"><%=Lang(pro.Name) %></a>
            </div>
            <div class="proinfo">
            <%if (pro.Price_Market > 0){ %><div class="marketprice"><i>市场价：</i><strong><%=FormatMoney(ProductPrice_Market(pro)) %></strong></div><%} %>
            <%if (pro.Type_id_ProductType == 321){ %>
            <div class="buyprice"><i>抢购价：</i><strong><%=FormatMoney(pro.Price_Sale) %></strong><em><%=Discount(pro.Price_Market,pro.Price_Sale) %>% 折</em></div>
			<%}else{%>
			<div class="buyprice"><i><%=Lang(CurrentUserLevel.PriceName) %>：</i><strong><%=FormatMoney(ProductPrice(pro)) %></strong></div>
            <%} %>
            <div class="introduction"><%=Lang(pro.Introduction)%></div>
            <div class="probtn">
                <%if(ProductStock(pro)<1 && SYS.IsNullStockSale!="1" && pro.Type_id_ProductType!=324){ %>
                <strong>已售罄</strong>
                <%}else{ %>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,142,$('#pro_num<%=pro.id%>').val());" class="buy btn btn-12"><s></s>加入购物车</a>
                <a href="javascript:void(0)" onclick="UserProduct_Edit(<%=pro.id%>,141);" class="fav btn btn-12"><s></s>收藏</a>
                <%} %>
            </div>
            </div>
        </li>
        <%} %>
        <%} %>
    </ul></div>
    <div class="clear"></div>
</div>
<%if (CurrentSite.IsMobile==0){ %>
<div class="footpage">
    <%=FootPage%>
</div>
<%}else{%>
<div class="loadpage">
    <a data-next="<%=NextPage%>"></a>
</div>
<script>
    $(document).ready(function () {
        var container = document.querySelector('.loadlist');
        var ias = $.ias({
            container: ".loadlist",
            item: ".loadli",
            pagination: ".loadpage",
            next: ".loadpage a"
        });
        ias.on('render', function (items) {
            //$(items).css({ opacity: 0 });
        });
        ias.on("rendered", function (items) {
        });
        ias.extension(new IASSpinnerExtension({ html: "<li class=\"loadinginfo\"><img src=\"{src}\" />&nbsp;加载中</li>" }));
        ias.extension(new IASTriggerExtension({ text: '加载更多', offset: 100, html: "<li class=\"loadinginfo more\"><p>{text}</p></li>" }));
        ias.extension(new IASNoneLeftExtension({
            text: '', html: ""
        }));
    });
</script>
<%}%>
</div>


        </div>
    </div>
    
<%
if(!IsAPP()){
%>
<div id="footnav">
<ul>
<li><a href="<%=URL("P_Index", "")%>"><img src="/Theme/system/wap/images/home.png" alt="首页" /><span>首页</span></a></li>
<li><a href="<%=URL("P_AllProductCategories", "")%>"><img src="/Theme/system/wap/images/category.png" alt="商品分类" /><span>商品分类</span></a></li>
<li><a href="<%=URL("P_Basket", "")%>"><img src="/Theme/system/wap/images/cart.png" alt="购物车" /><span>购物车</span></a></li>
<li><a href="<%=URL("P_UserCenter", "")%>"><img src="/Theme/system/wap/images/user.png" alt="会员中心" /><span>会员中心</span></a></li>
</ul>
</div>
<%}%>

    
</body>
</html><div style="width:100%;text-align:center;font-size:12px;color:#999">Powered by <a style="font-size:12px;color:#00497f" href="http://www.lebi.cn/support/license/?url=" target="_blank" title="LebiShop多语言网店系统">LebiShop</a> V<%=SYS.Version%>.<%=SYS.Version_Son%></div>