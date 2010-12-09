/***************************/
/*   Javasccript for table */
/*   Auhtor:   Foolin      */
/*   Created: 2010-8-11    */
/*   Updated: 2010-08-19   */
/*   Version: 1.0.1        */
/***************************/

function onloadEvent(func) {
    var one = window.onload
    if (typeof window.onload != 'function') {
        window.onload = func
    } else {
        window.onload = function() {
            one();
            func();
        }
    }
}

onloadEvent(loadTableCss);

function loadTableCss()
{
	var tableId = "FLTable";
	for(var i = 0; i < 10; i++)
	{
		var tempTableId = tableId;
		if(i > 0)
		{
			tempTableId = tempTableId + i;
		}
		if(isExistID(tempTableId))
		{
			initTableCss(tempTableId);
			//alert(tempTableId)
		}
		
	}
}


function initTableCss(tableId)
{
	var oTable = isExistID(tableId); 
	var evenRowClass = "evenRowClass";	//ż��
	var oddRowClass = "oddRowClass";	//����
	var onRowClass = "onRowClass";	//����
	
	//��ֵClass
	oTable.className = "Foolin";
	
	for (var i=1;i<oTable.rows.length;i++)
	{
		 //��ʼ���������
		if(i%2==0)
		{
		  oTable.rows[i].className=evenRowClass;
		}
		else
		{
			oTable.rows[i].className=oddRowClass;
		}
		//����¼�onmouseover
		oTable.rows[i].onmouseover = function(){
			//this.style.background = '#b5e28d'
			this.className= onRowClass;
		}
		//����¼�onmouseout
		oTable.rows[i].onmouseout = function(){ 
			if(this.rowIndex%2==0)
			{
				this.className=evenRowClass;
			}
			else
			{
				this.className=oddRowClass;
			}
		}
	}
}

function isExistID(id)
{
	if(typeof(id) == "object")
	{
		return id;
	}
	var oTable = document.getElementById(id); 
	if (oTable != null){ 
		//Exist ID
		return oTable;
	}else{ 
		//No Exist ID
		return false;
	}
}

