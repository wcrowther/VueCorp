

function PagerModel (search, pageSize, groupSize)
{
    this.pages              = []

    this.CurrentRecord      = 1
    this.PageSize           = pageSize || 15
    this.GroupSize          = groupSize || 5
    this.TotalCount         = 0
    this.Search             = search || new SearchModel()

    // Record Functions =============================================================================

    this.currentFirst       = function() { return this.firstRecordInPage(this.currentPage()) }
    this.previous           = function() { return this.CurrentRecord != 1 ? this.CurrentRecord - 1 : this.TotalCount }
    this.next               = function() { return this.hasRecords() && this.CurrentRecord < this.TotalCount ? this.CurrentRecord + 1 : 1 }
    this.hasRecords         = function() { return this.TotalCount > 0 }
    this.offset             = function() { var offset = this.CurrentRecord - ((this.currentPage() - 1) * this.PageSize) - 1; return offset > 0 ? offset : 0 };

    // Page Functions =============================================================================

    this.currentPage        = function() { return Math.ceil(this.CurrentRecord / this.PageSize) }
    this.firstPage          = function() { return 1 }
    this.lastPage           = function() { return Math.ceil(this.TotalCount / this.PageSize) }
    this.previousPage       = function() { return this.currentPage() <= 1 ? this.lastPage() : this.currentPage() - 1 }
    this.nextPage           = function() { return this.currentPage() * this.PageSize >= this.TotalCount ? this.firstPage() : this.currentPage() + 1 } 
    this.hasMultiplePages   = function() { return this.TotalCount > this.PageSize } 

    // Group Functions =============================================================================

    this.currentGroup       = function() { return Math.ceil(this.CurrentRecord / (this.GroupSize * this.PageSize)) }
    this.firstGroup         = function() { return 1 }
    this.lastGroup          = function() { return Math.ceil(this.TotalCount / (this.GroupSize * this.PageSize)) }
    this.previousGroup      = function() { return this.currentGroup() <= 1 ? this.lastGroup() : this.currentGroup() - 1 }
    this.nextGroup          = function() { return this.currentGroup() >= this.lastGroup()  ? 1 : this.currentGroup() + 1 }
    this.hasPreviousGroup   = function() { return this.currentGroup() > 1 }
    this.hasNextGroup       = function() { return this.TotalCount > this.currentGroup() * (this.PageSize * this.GroupSize) }

    // Utility Functions =============================================================================

    this.firstRecordInPage  = function(page)  { var firstRecordInPage = ((page - 1) * this.PageSize) + 1;   return firstRecordInPage > 1 ? firstRecordInPage : 1 }
    this.firstRecordInGroup = function(group) { var firstPageInGroup = this.firstPageInGroup(group);        return this.firstRecordInPage(firstPageInGroup) } 
    this.firstPageInGroup   = function(group) { var firstPageIn = ((group - 1) * this.GroupSize) + 1;       return firstPageIn > 1 ? firstPageIn : 1 }
   
    // Top level GoTo ================================================================================

    // REFRESH PAGER
    this.goToRecord         = function(newRecord){ this.CurrentRecord = newRecord; }
    this.goToPage           = function(newPage)  { this.goToRecord(this.firstRecordInPage(newPage)); }
    this.goToGroup          = function(newGroup) { this.goToRecord(this.firstRecordInGroup(newGroup)); }

    // Record ========================================================================================

    this.goToNext           = function(){ this.goToRecord(this.next()); }
    this.goToPrevious       = function(){ this.goToRecord(this.previous()); }
    
    // Page GoTo =====================================================================================

    this.goToFirstPage      = function(){ this.goToPage(this.firstPage()); }
    this.goToLastPage       = function(){ this.goToPage(this.lastPage()); }
    this.goToPreviousPage   = function(){ this.goToPage(this.previousPage()); }
    this.goToNextPage       = function(){ this.goToPage(this.nextPage()); }

    // Group GoTo ====================================================================================

    this.goToFirstGroup     = function(){ this.goToGroup(this.firstGroup()); }
    this.goToLastGroup      = function(){ this.goToGroup(this.lastGroup()); }
    this.goToPreviousGroup  = function(){ this.goToGroup(this.previousGroup()); }
    this.goToNextGroup      = function(){ this.goToGroup(this.nextGroup()); }

    //  ==============================================================================================

    this.createPages =  function() 
    {
        this.pages = [];
        
        var beginpage = this.firstPageInGroup(this.currentGroup());
        var endPage   = (beginpage + this.GroupSize) - 1;

        // console.log('createPages TotalCount: ' + this.TotalCount);
        // console.log(beginpage + " to " + endPage);

        for (var i = beginpage; i <= endPage; i++)
        {
            var firstInPage = ((i - 1) * this.PageSize) + 1;
            if (firstInPage > this.TotalCount)
            {
                break;
            }
            var isSelected = (this.currentPage() === i);
            var pItem = new PageItem(i.toString(), firstInPage, i, isSelected);

            this.pages.push(pItem);
        }
    }
}

function SearchModel(filter, filterType, sort, sortDesc)
{
    this.Filter     = filter || ''
    this.FilterType = filterType || 'startswith'      
    this.Sort       = sort || ''
    this.SortDesc   = (typeof sortDesc != 'undefined') ? sortDesc : false
}

function SearchForAccount(filter, filterType, sort, sortDesc, stateProvinceFilter, postalCodeFilter)
{
    this.Filter     = filter || ''
    this.FilterType = filterType || 'startswith'      
    this.Sort       = sort || ''
    this.SortDesc   = (typeof sortDesc != 'undefined') ? sortDesc : false

    this.StateProvinceFilter  = stateProvinceFilter || ''
    this.PostalCodeFilter     = postalCodeFilter || ''
}

function Result(success, message)
{
    this.Success    = success || false
    this.Message    = message || "Result not successful."
}

function PageItem(display, record, page, selected)
{
    this.Display    = display
    this.Record     = record
    this.Page       = page
    this.Selected   = selected
}

function PagedList (pager, list, result)
{
    this.Pager      = pager
    this.ListItems  = list || []
    this.Result     = result  || new Result()
}

export
{
    PagerModel,
    PageItem,
    PagedList,
    SearchModel,
    SearchForAccount
}
