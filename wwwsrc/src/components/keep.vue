<template>
  <div class="keep">
    <div class="card" style="width: 18rem;">
      <img :src="keepData.img" class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <i
          class="far fa-edit"
          title="edit"
          @click="editKeep(keepData, keepData.id)"
        ></i>
        <i
          class="far fa-times-circle"
          title="delete"
          @click="deleteKeep(keepData.id)"
        ></i>
        <p class="card-text">{{ keepData.description }}</p>
        <a href="#" class="btn btn-primary">Go somewhere</a>
        <i class="far fa-eye" title="view"></i>
        {{ keepData.views }}
        <i class="far fa-bookmark" title="keep"></i>
        {{ keepData.keeps }}
        <i class="fas fa-share" title="share"></i>
        {{ keepData.shares }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepData"],
  computed: {},
  methods: {
    async editKeep(keep, keepId) {
      let currentKeep = await NotificationService.inputData("Keep", keep);
      if (currentKeep) {
        this.$store.dispatch("editKeep", {
          update: keepUpdate,
          Id: keepId
        });
      }
    },
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    }
  }
};
</script>

<style></style>
