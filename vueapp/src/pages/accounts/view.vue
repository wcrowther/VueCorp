<script setup>

    const appStore                  = useAppStore()
    const { sideBarHidden }         = storeToRefs(appStore)

    const accountsStore     	= useAccountsStore()
    const { accountsAll } 		= storeToRefs(accountsStore)
    const { getAllAccounts }	= accountsStore

    const showActive            = ref(true)
    const showInActive          = ref(true)
    const accountTitle          = ref('Accounts View Page')
    const detailIndex           = ref(1)
    const showDetail            = ref(false)
    const fullScreen            = ref(false)
    const enableWideScreen      = ref(false)
    const numberButton          = ref(0)

    const addAccount    = () => alert('Add Account?')

    const getListData = async () =>
    {
        await getAllAccounts()
    } 

    onMounted(() =>    
    {        
        getListData()
    })

</script>

<template>

    <div class="relative" id="accounts-view">

        <div class="z-0 bg-gradient-main h-[500px] absolute top-0 left-0 right-0"></div>

        <div class="p-5 pt-5 sm:p-10 sm:pt-5 pb-14">
            <div class="flex justify-between items-center mb-7 relative z-20">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ accountTitle }}</h2>
                <span class="flex flex-wrap gap-1.5">
                    <button class="btn-primary" @click="addAccount">Add</button>
                    <!-- <button class="btn-delete" @click="confirmSave">Cancel</button> -->
                </span>
            </div>
            <div class="w-full min-h-[400px] relative z-20">
            
                <div v-if="!sideBarHidden" 
                    class="bg-gradient-side-alt mb-7 p-5 flex justify-between items-center">

                    <div class="flex justify-around items-center p-3 gap-3 w-full">
                        <CheckboxInput class="mr-3" backcolor="white" labelName="Active" v-model="showActive" />
                        <CheckboxInput class="mr-3" backcolor="white" labelName="InActive" v-model="showInActive" />
                    </div>

                    <div class="flex gap-x-1 w-full max-w-[400px] ">
                        <div class="h-10 flex w-full justify-center items-center relative">
                            <input class="rounded-full w-full h-full pl-5 pr-5 sm:pr-9 select-all border-color-dark-gray"
                                id="filterInput" type="text"  placeholder="Text to search" spellcheck="false"
                                title="Search the list for Account Names that start with this text. Add multiple 
                                        conditions separated by a comma. Click on + for more options."
                            />
                            <IconSymbol class="hidden sm:block absolute right-3" color="text-color-dark-gray" 
                                width="24px" :inline="false" icon="heroicons:x-mark-16-solid" /> 
                        </div>
                        <div class="rounded-full h-10 w-12 flex justify-center items-center cursor-pointer bg-color-light-gray hover:bg-white"
                            title="Advanced Search">
                            <IconSymbol color="#868686" class="" width="24px" icon="heroicons:plus-20-solid" />
                        </div> 
                    </div>
                </div>

                
            <MasterDetail class="mb-10" 
                v-model:detailIndex="detailIndex" v-model:showDetail="showDetail" 
                :fullScreen="fullScreen" :colsVisible="numberButton"
                :enableWideScreen  gridTemplateColumns="50px 2fr 1fr 2fr 2fr">

                <template #master>

                    <div class="py-2 border-b-4 border-gray-300 font-bold">Id</div>
                    <div class="py-2 border-b-4 border-gray-300 font-bold">Account Name</div>
                    <div class="py-2 border-b-4 border-gray-300 font-bold">Status</div>
                    <div class="py-2 border-b-4 border-gray-300 font-bold">Email</div>
                    <div class="py-2 border-b-4 border-gray-300 font-bold">Feed Url</div>

                    <template v-for="(act, idx) in accountsAll" :key="act.AccountId">
                        <span :class="[ { selected: detailIndex === idx+1 },'data-row hover-row']"
                              class="py-3 border-b border-gray-300">{{ act.AccountId }}</span>
                        <span class="py-3 border-b border-gray-300">{{ act.AccountName }}</span>
                        <span class="py-3 border-b border-gray-300">{{act.IsActive ? 'Active' :'Inactive'}}</span>
                        <span class="py-3 border-b border-gray-300">{{ act.AccountEmail }}</span>
                        <span class="py-3 border-b border-gray-300">{{ act.AccountUrl }}</span>
                    </template>

                </template>

                <template #detail>
                
                    <div class="w-full h-full border border-red"> xxx</div>
                    <!-- ="detailProps"
                    <template v-for="(co, idx) in companyList" :key="idx">

                        <div v-if="detailIndex === idx+1"
                            class="bg-white p-5 h-full w-full pointer-events-auto border border-black">
                            <h3 class="text-lg font-bold">{{ co.company }}</h3>
                            {{ co.content }}
                            <div class="border border-black p-3 mt-2">DetailProps.isWideScreen(from component): {{ detailProps.isWideScreen }}</div>
                            <div class="mt-10">
                                <button class="custom-button pointer-events-auto" 
                                @click="showDetail = false">Ok</button>
                            </div>
                        </div>

                    </template> -->

                </template>

            </MasterDetail> 

                <!-- <div class="py-3 pl-3 pr-3 mb-3 border-y-2 border-color-light-blue last:border
                    bg-slate-300 flex flex-wrap justify-between items-start">
                    <div class="w-36 flex-grow">Id</div>
                    <div class="w-36 flex-grow font-bold">Account Name</div>
                    <div class="w-20 pl-1 text-right xs:text-left">Status</div>
                    <div class="w-40 flex-grow">Email</div>
                    <div class="w-60 flex-grow">Feed Url</div>
                    <div class="w-40 flex-grow">Modified</div>
                    <div class="w-12 flex-grow text-right">Actions</div>
                </div>
                <div v-for="act in accountsAll" :key="act.AccountId"
                    class="py-3 border-b border-color-dark-gray last:border-b flex flex-wrap justify-between items-start gap-y-2">
                    <span class="w-40 flex-grow font-bold">{{ act.AccountId }}</span>
                    <span class="w-40 flex-grow font-bold">{{ act.AccountName }}</span>
                    <span class="w-20 text-right xs:text-left">{{act.IsActive ? 'Active' :'Inactive'}}</span>
                    <span class="w-40 flex-grow">{{ act.AccountEmail }}</span>
                    <span class="w-60 flex-grow">{{ act.AccountUrl }}</span>
                    <span class="w-40 flex-grow">Dec. 6, 2023</span>
                    <span class="w-12 flex-grow flex justify-end">
                        <button class="btn-primary">Edit</button>
                    </span>
                </div>  -->

            </div>
        </div>

    </div>  

</template>

<style scoped>

    .selected       { @apply border-r-white border-r-8 border-opacity-80 text-black }
</style>
