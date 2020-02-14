<template>
  <div class="keep card border-none bg-beige" style="width: 18rem;">
    <div class="text-center p-4">
      <img src="../assets/frame.png" class="border-frame" />
      <img :src="keepData.img" class="card-img-top" alt="..." />
      <div class="card-body position-custom">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <div class="edit-delete-btns">
          <i class="far fa-edit pr-1" title="edit" @click="editKeep(keepData)"></i>
          <i
            class="far fa-times-circle"
            v-if="!this.$route.params.vaultId"
            title="delete"
            @click="deleteKeep(keepData.id)"
          ></i>
          <i
            class="far fa-times-circle"
            v-if="this.$route.params.vaultId"
            title="remove"
            @click="removeKeepFromVault(keepData.id)"
          ></i>
        </div>
        <p class="card-text">{{ keepData.description }}</p>
        <div class="d-flex justify-content-center">
          <!-- SECTION views -->
          <button class="btn" title="view" @click="viewKeep(keepData)">
            <i class="far fa-eye"></i>
            {{ keepData.views }}
          </button>

          <!-- SECTION keeps -->
          <div class="btn-group">
            <button
              type="button"
              class="btn dropdown-toggle"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
              title="keep"
            >
              <i class="far fa-bookmark"></i>
              {{ keepData.keeps }}
            </button>
            <div class="dropdown-menu">
              <button
                class="dropdown-item"
                type="button"
                v-for="vault in vaults"
                :key="vault.id"
                @click="keepKeep(keepData, vault)"
              >{{ vault.name }}</button>
            </div>
          </div>

          <!-- SECTION shares -->
          <button class="btn">
            <i class="fas fa-share" title="share"></i>
            {{ keepData.shares }}
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NotificationService from "../NotificationService";
export default {
  name: "keep",
  props: ["keepData"],
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    async editKeep(keep) {
      let keepUpdate = await NotificationService.inputData("Edit keep", keep);
      if (keepUpdate) {
        this.$store.dispatch("editKeep", {
          update: keepUpdate,
          id: keep.id
        });
      }
    },
    viewKeep(keepData) {
      NotificationService.viewKeep("View", keepData);
      keepData.views++;
      this.$store.dispatch("editKeep", {
        update: keepData,
        id: keepData.id
      });
    },
    keepKeep(keepData, vault) {
      this.$store.dispatch("addKeepToVault", {
        keepData: keepData,
        vaultId: vault.id
      });
    },
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    },
    removeKeepFromVault(keepId) {
      this.$store.dispatch("removeKeepFromVault", {
        keepId: keepId,
        vaultId: this.$route.params.vaultId
      });
    }
  }
};
</script>

<style>
.bg-beige {
  background-color: #cfcebd;
}
.border-none {
  border: none;
}
.border-frame {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  border: none;
}
button {
  z-index: 1;
}
.edit-delete-btns {
  /* color: purple; */
  cursor: pointer;
  /* FIXME btns are behind frame and cannot be selected */
  position: absolute;
  top: 0.1em;
  right: 0.4em;
  opacity: 0.3;
}
.edit-delete-btns:hover {
  opacity: 0.7;
}
.position-custom {
  position: relative;
}
</style>
