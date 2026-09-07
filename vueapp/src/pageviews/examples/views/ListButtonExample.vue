<script setup>

    // INDEXES
    const animal            = ref(0)
    const color             = ref(0)
    const webPageIndex      = ref(0)

    const selectedAnimal    = ref(null)
    const selectedPage      = ref(null)

    const animalList        = ['Cats','Dogs','Tigers','Bears','Lions']
    const colors            = ['Red','Yellow','Blue','Green','Orange']

    const webPages 		    = 
    [
        { name: 'Cnn',      url: 'https://www.cnn.com'},
        { name: 'Time',     url: 'https://www.time.com'},
        { name: 'UsaToday', url: 'https://www.usatoday.com'},
    ]

</script>

<template>

    <div class="w-full">

        <PageTitleBox pageTitle="List Index Button" />

        <InfoBox>
            The <b>ListButton</b> is a lightweight prev/next navigator for stepping through any array. 
            It binds to a zero-based index via <code>v-model</code> and accepts any array as <code>:rangeList</code>. 
            By default it displays the item's <code>name</code> property, but you can override this with the 
            <code>textName</code> prop. Set <code>:wrapBack="false"</code> to prevent cycling past the first or last item.
        </InfoBox>
        
        <div class="flex flex-wrap gap-[10px] @container" v-container-width>

            <div class="w-full @xl:flex-1">
                <div class="basis-full mb-5">
                    <ListButton v-model:index="animal" :rangeList="animalList" class="w-fit mb-2" />
                    Animal Ordinal - 1-based ({{ animal+1 }}): {{ animalList[animal] }}
                </div>
                <div class="basis-full mb-5">
                    <ListButton v-model:index="color" :rangeList="colors" :wrapBack="false" class="w-fit mb-2" />
                    Color ({{ color+1 }}) - does not wrap: {{ colors[color] }}
                </div>
                <div class="basis-full flex flex-wrap gap-2 mb-5">
                    <ListButton v-model:index="webPageIndex" :rangeList="webPages" class="w-fit mb-2 inline-block"/>
                    <ListButton v-model:index="webPageIndex" :rangeList="webPages" textName="url" class="w-fit mb-2 inline-block" />
                    <div class="basis-full flex-none">
                        Web Pages ({{ webPageIndex }}) : {{ webPages[webPageIndex].url }}
                    </div>
                </div>
                <div class="basis-full mb-5">
                    <ListButton v-model:value="selectedAnimal" :rangeList="animalList" class="w-fit mb-2" />
                    Selected animal (no index needed): {{ selectedAnimal }}
                </div>
            </div>

            <div class="w-full @xl:flex-1 p-5 pb-7 border border-blue">
                <div class="basis-full mb-5">
                    <ListButton v-model:index="animal" :rangeList="animalList" class="w-fit mb-2" />
                    Animal Ordinal - 1-based ({{ animal+1 }}): {{ animalList[animal] }}
                </div>
            </div>  

        </div>

    </div>

</template>