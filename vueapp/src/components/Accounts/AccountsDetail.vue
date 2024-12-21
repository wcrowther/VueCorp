<script setup>

    const accountsStore                 = useAccountsStore()
    const { account, detailAccountId }  = storeToRefs(accountsStore)
    const 
    { 
        getAccountDetailData,
        addNewAccount, 
        saveAccount
    }                                   = accountsStore

    const isAddingAccount               = ref(false)
    const isConfirmVisible              = ref(false)

	const rules = computed(() => accountValidator)
  
	const v$ = useVuelidate(rules, account)

    const accountTitle = computed(() => isAddingAccount.value ? 'Add new Account' : (hasKeys(account.value) ? account.value.AccountName : 'Accounts') )

    const getAccountDetail = async () =>
    {
        if(detailAccountId.value === 0)
            return

        isAddingAccount.value   = false
        getAccountDetailData(detailAccountId.value)
    }

    const addAccount = () =>
    {
       isAddingAccount.value = true 
       addNewAccount()
    }

    const cancelAdd = () =>
    {
       isAddingAccount.value = false 
       v$.value.$reset()
       getAccountDetail()
    }

    const confirmSave = async () =>
    {
        const isValidAccount = await v$.value.$validate()
        if(isValidAccount)
        {
            isConfirmVisible.value = true
        }
    }

    const saveAccountDetail = async () =>
    {
        saveAccount()
        isAddingAccount.value = false 
        isConfirmVisible.value = false
    }

    const cancelAction = () => 
    {
        isConfirmVisible.value = false
        v$.value.$reset()
        // getAccountDetail()
    }


    // Keyboard Listeners  =====================================================================

    const keys = function (e)   
    {
        let ctrl = navigator.userAgentData.platform.match("Mac") ? e.metaKey : e.ctrlKey   
        if (e.code === 'KeyS' && ctrl) { confirmSave();  e.preventDefault(); }
    }

	KeyboardListeners(keys)

    // Lifecycle & Watches  ==========================================================================

    onMounted(()    => 
    {
        getAccountDetail()
    })

    watch(() => detailAccountId.value, (newVal, oldVal) => 
    {
        // console.log('Account accountId newval: ' + newVal + ' oldVal: ' + oldVal)

        if(newVal === oldVal) 
            return

        getAccountDetail()  
    });

    // ===============================================================================================

</script>

<template>
    <div class="flex flex-wrap gap-5" id="AccountsDetailView">
        
        <ConfirmDialog :isVisible="isConfirmVisible"
			message="Save Account Data?" @confirm="saveAccountDetail" @cancel="cancelAction" />

        <div class="w-full flex justify-between items-center">
            <h2 class="text-2xl font-display font-bold flex-grow">{{ accountTitle }}</h2>
            <span class="flex flex-wrap gap-1.5"> 
                <!--               
                    <span class="">{{isAddingAccount}}</span>
                    <span class="">{{hasKeys(account)}}</span> 
                    <span class="">{{account.AccountId}}</span> 
                -->
                <button v-if="isAddingAccount || hasKeys(account) && account.AccountId > 0" 
                    class="btn-primary" @click="confirmSave">Save</button>
                <button v-if="!isAddingAccount" class="btn-primary"
                    @click="addAccount">Add</button>    
                <button v-else class="btn-delete" @click="cancelAdd">Cancel</button>
            </span>
        </div>

        <div v-if="(!account || account.AccountId === 0)  && !isAddingAccount" class="w-[300px] font-bold">
            No Account to display
        </div>

        <div v-if="account && account.AccountId > 0 || isAddingAccount"  
             class="w-[300px] flex-1 border border-color-blue-gray bg-white">

            <div class="p-5 min-w-[200px] relative grow linear-gray">

                <div class="mb-3 pb-1 flex justify-end">
                    <span class="text-color-dark-blue font-bold whitespace-nowrap text-sm">
                        Account Id: {{account.AccountId}}
                    </span>
                </div>
                
                <TextInput labelName="Account Name" v-model="account.AccountName" :v$ />
                <TextInput labelName="Main Email" ruleName="AccountEmail" v-model="account.AccountEmail" :v$ />
                <PhoneInput labelName="Main Phone" ruleName="AccountPhone" v-model="account.AccountPhone" :v$ />

                <!-- 
                <div class="mt-7 flex flex-wrap gap-5 mb-3">
                    <SwitchButton class="bg-color-mid-blue text-white transition-colors" buttonName="Active"  
                        :class="{'!bg-color-dark-blue' : account.IsActive}" v-model="account.IsActive" />
                </div> 
                -->

                <div class="mt-7 flex flex-wrap gap-5 mb-3">
                    <CheckboxInput labelName="Is Active" v-model="account.IsActive" />
                    <CheckboxInput labelName="Is Invoice" v-model="account.IsInvoice" />
                    <CheckboxInput labelName="Is AutoPay" v-model="account.IsAutoPay" />
                </div>

            </div>
        </div>

        <div v-if="account && account.AccountId > 0 || isAddingAccount"  
            class="w-[300px] flex-1 border border-color-blue-gray bg-white">

            <div class="p-5 min-w-[200px] relative grow linear-gray">
                <TextInput labelName="Street Address" v-model="account.StreetAddress" :v$ />
                <TextInput labelName="City" ruleName="City" v-model="account.City" :v$ />
                <SelectInput labelName="State / Province" ruleName="StateProvince" v-model="account.StateProvince" 
                    :optionsList="usStatesList" defaultText="-- Pick a State --" :v$ />
                <TextInput labelName="Postal Code" ruleName="PostalCode" v-model="account.PostalCode" :v$ />
            </div>
        
        </div>
    </div>

</template>

<style lang="postcss" scoped></style> 

<!-- 
    <TextInput   labelName="State / Province" ruleName="StateProvince" v-model="account.StateProvince" :v$></TextInput>
    <div class="mb-3">
        <span class="text-color-dark-blue font-bold whitespace-nowrap text-sm">States</span>
        <span v-for="error in v$.StateProvince.$errors" :key="error.$uid"
            class="italic font-bold text-right text-xs text-color-red">
            {{ error.$message }}
        </span>
        <select class="w-full p-2.5" name="states" id="states" v-model="account.StateProvince">
            <option value="">--- Select ---</option>
            <option v-for="(value,key) in usStatesList" :key="key" :value="key">{{ value }}</option>
        </select>
    </div> 
-->