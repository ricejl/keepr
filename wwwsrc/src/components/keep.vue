<template>
  <div class="keep">
    <div class="card" style="width: 18rem;">
      <img :src="keepData.img" class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <p class="card-text">
          {{ keepData.description }}
        </p>
        <a href="#" class="btn btn-primary">Go somewhere</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepData"],
  computed: {},
  methods: {}
};
</script>

<style></style>
