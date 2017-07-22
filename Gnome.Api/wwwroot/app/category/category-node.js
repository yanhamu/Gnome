const CategoryNode = Vue.component('category-node', {
    props: ['node'],
    template: `
    <div>
    <li>
        {{ node.name }}
    </li>
    <ul v-if="node.hasChildren">
        <category-node v-bind:node="node" v-for="node in node.children" :key="node.id"></category-node>
    </ul>
    </div>`
});